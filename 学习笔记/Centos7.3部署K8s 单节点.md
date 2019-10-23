
参考来源：https://www.58jb.com/html/152.html


#配置yum源：

cat >/etc/yum.repos.d/kubernetes.repo<<-EOF 
[virt7-docker-common-release] 
name=virt7-docker-common-release 
baseurl=http://cbs.centos.org/repos/virt7-docker-common-release/x86_64/os/ 
gpgcheck=0 
EOF

#安装所需要的包：

yum -y install --enablerepo=virt7-docker-common-release kubernetes etcd

#配置文件的修改：
vi /etc/sysconfig/docker

#添加代码，使用内网仓库：
ADD_REGISTRY='--add-registry reg.docker.lc'

vi /etc/kubernetes/apiserver

KUBE_API_ADDRESS="--insecure-bind-address=0.0.0.0"     #这里把127.0.0.1改成0.0.0.0 

去掉ServiceAccount即可；

KUBE_ADMISSION_CONTROL="--admission-control=NamespaceLifecycle,NamespaceExists,LimitRanger,Security 
ContextDeny,ResourceQuota"

把服务添加到启动项，并启动服务：

for SERVICE in docker etcd kube-apiserver kube-controller-manager kube-scheduler kube-proxy kubelet; do  
systemctl start $SERVICE 
    systemctl enable $SERVICE 
done

升级系统 Centos系统版本会存在某些兼容性问题

yum update

重启docker
systemctl restart docker

解决 docker pull registry.access.redhat.com/rhel7/pod-infrastructure:latest错误

yum install *rhsm* -y


wget http://mirror.centos.org/centos/7/os/x86_64/Packages/python-rhsm-certificates-1.19.10-1.el7_4.x86_64.rpm

rpm2cpio python-rhsm-certificates-1.19.10-1.el7_4.x86_64.rpm | cpio -iv --to-stdout ./etc/rhsm/ca/redhat-uep.pem | tee /etc/rhsm/ca/redhat-uep.pem



上传yaml文件



注意：镜像最好先下载到本地，不然可能会出现错误，如Error或ImagePullBackOff




创建实例：
Kubectl create -f kubernetes-dashboard.yaml



访问http://39.106.221.26:8080/api/v1/proxy/namespaces/kube-system/services/kubernetes-dashboard/#!/namespace?namespace=default
效果图如下：


