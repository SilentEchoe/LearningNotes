# Centos 部署K8s单节点


## 本文参考来源：https://www.58jb.com/html/152.html 
## 解决方案来源：https://blog.csdn.net/qq_29308413/article/details/88890526
##              https://blog.csdn.net/ffzhihua/article/details/85237411  


## 配置yum源：

cat >/etc/yum.repos.d/kubernetes.repo<<-EOF 
[virt7-docker-common-release] 
name=virt7-docker-common-release 
baseurl=http://cbs.centos.org/repos/virt7-docker-common-release/x86_64/os/ 
gpgcheck=0 
EOF

## 安装所需要的包：
yum -y install --enablerepo=virt7-docker-common-release kubernetes etcd

## 修改 /etc/sysconfig/docker 配置文件，并添加如下代码：
ADD_REGISTRY='--add-registry reg.docker.lc'

## 修改/etc/kubernetes/apiserver 配置文件
KUBE_API_ADDRESS="--insecure-bind-address=0.0.0.0"     #这里把127.0.0.1改成0.0.0.0 


KUBE_ADMISSION_CONTROL="--admission-control=NamespaceLifecycle,NamespaceExists,LimitRanger,Security 
ContextDeny,ResourceQuota"  # 去掉ServiceAccount

## 把服务添加到启动项，并启动服务：

for SERVICE in docker etcd kube-apiserver kube-controller-manager kube-scheduler kube-proxy kubelet; do  
systemctl start $SERVICE 
    systemctl enable $SERVICE 
done

## 升级系统 （PS：Centos系统版本会存在某些兼容性问题）
yum update

## 升级完毕后重启docker
systemctl restart docker


## 解决details: (open /etc/docker/certs.d/registry.access.redhat.com/redhat-ca.crt: no such file or directory)异常

yum install *rhsm* -y

## 安装完成之后 执行 docker pull registry.access.redhat.com/rhel7/pod-infrastructure:latest
## 如果报错 执行以下命令

wget http://mirror.centos.org/centos/7/os/x86_64/Packages/python-rhsm-certificates-1.19.10-1.el7_4.x86_64.rpm

rpm2cpio python-rhsm-certificates-1.19.10-1.el7_4.x86_64.rpm | cpio -iv --to-stdout ./etc/rhsm/ca/redhat-uep.pem | tee /etc/rhsm/ca/redhat-uep.pem


## 将kubernetes-dashboard.yaml 文件上传到服务器上

## 注意：镜像最好先下载到本地 不然创建实例时可能会报错

## 创建实例：
Kubectl create -f kubernetes-dashboard.yaml

## 查看是否成功运行：
kubectl get pods --all-namespaces 

## 访问http://服务器外网IP:8080/api/v1/proxy/namespaces/kube-system/services/kubernetes-dashboard/#!/namespace?namespace=default

## 记得开放防火墙 8080 端口