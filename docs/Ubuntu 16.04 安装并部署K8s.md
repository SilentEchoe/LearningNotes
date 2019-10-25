1.安装Docker 并配置环境
	1.1  卸载旧版本Docker
	apt-get remove docker docker-engine docker.io
	
	1.2  更新apt-get 源
	add-apt-repository  "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"
	apt-get update
	
	1.3  安装apt和https支持包并添加gpg密钥
	
	apt-get install \
	    apt-transport-https \
	    ca-certificates \
	    curl \
	    software-properties-common
	
	curl -fsSL https://download.docker.com/linux/ubuntu/gpg | apt-key add -
	
	1.4  安装必要的系统工具
	
		sudo apt-get -y install apt-transport-https ca-certificates curl software-properties-common
	
		1.4.1  安装GPG证书
	
		curl -fsSL http://mirrors.aliyun.com/docker-ce/linux/ubuntu/gpg | sudo apt-key add -

		1.4.2  写入软件源信息
		sudo add-apt-repository "deb [arch=amd64] http://mirrors.aliyun.com/docker-ce/linux/ubuntu $(lsb_release -cs) stable"
	
		1.4.3  更新并安装Docker-ce
		sudo apt-get -y update
		sudo apt-get -y install docker-ce
	
	1.5 接受所有IP的数据包转发
	 vi /lib/systemd/system/docker.service
	# 找到ExecStart=xxx 在这行上面加入一行，内容如下(K8s的网络需要)：
	ExecStartPost=/sbin/iptables -I FORWARD -s 0.0.0.0/0 -j ACCEPT
	
	1.6 启动服务
	systemctl daemon-reload
	service docker restart
	
2.系统设置

	2.1 禁用防火墙(让所有机器之间都可以通过任意端口建立连接)
		ufw disable
#查看状态
$ ufw status
		
	2.2设置系统参数 允许路由转发，不对bridge的数据进行处理
		2.2.1写入配置文件
		cat <<EOF > /etc/sysctl.d/k8s.conf
		net.ipv4.ip_forward = 1
		net.bridge.bridge-nf-call-ip6tables = 1
		net.bridge.bridge-nf-call-iptables = 1
		EOF
		
		#配置文件生效
		sysctl -p /etc/sysctl.d/k8s.conf
	
	2.3配置host,使每个node都可以通过名字解析到IP地址
		2.3.1 查询IP地址
			$ ifconfig -a
			
			
	
			Eth0的IP地址 ： 172.24.54.206
			
		2.3.2 修改hosts文件
			Vi /etc/hosts
			#加入如下片段：
			172.24.54.206 server02
			

3.安装K8S并配置
	3.1上传kubernetes-bins.tar.gz 文件到 /home/michael 目录
	#解压二进制文件
	tar -zxvf archive_name.tar.gz 
	
	#更改文件夹名
	mv  kubernetes-bins/ bin/
	
	#准备配置文件（所有节点）
	#下载配置文件
	#在home目录下下载项目
	
	git clone  https://github.com/liuyi01/kubernetes-starter.git
	
	
	3.2 文件说明
	
	gen-config.sh
	shell脚本，用来根据每个同学自己的集群环境(ip，hostname等)，根据下面的模板，生成适合大家各自环境的配置文件。生成的文件会放到target文件夹下。
	
	kubernetes-simple
	简易版kubernetes配置模板（剥离了认证授权）。 适合刚接触kubernetes的同学，首先会让大家在和kubernetes初次见面不会印象太差（太复杂啦~~），再有就是让大家更容易抓住kubernetes的核心部分，把注意力集中到核心组件及组件的联系，从整体上把握kubernetes的运行机制。
	
	kubernetes-with-ca
	在simple基础上增加认证授权部分。大家可以自行对比生成的配置文件，看看跟simple版的差异，更容易理解认证授权的（认证授权也是kubernetes学习曲线较高的重要原因）

	service-config
	这个先不用关注，它是我们曾经开发的那些微服务配置。 等我们熟悉了kubernetes后，实践用的，通过这些配置，把我们的微服务都运行到kubernetes集群中。

	3.3 生成配置
	这里会根据大家各自的环境生成kubernetes部署过程需要的配置文件。 在每个节点上都生成一遍，把所有配置都生成好，后面会根据节点类型去使用相关的配置。
	
	#cd 到之前下载的git代码目录
	cd  /kubernetes-starter
	#编辑属性配置（根据文件注释中的说明填好每个Key-Value）
	vi config.properties
	
	#生成配置文件，确保执行过程没有异常信息
	./gen-config.sh simple
	
	#查看生成的配置文件，确保脚本执行成功
	find target/ -type f
	
	
	
