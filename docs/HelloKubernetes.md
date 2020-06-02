---
title: Kubernetes单节点部署
date: 2020-5-1 12:00:00
tags: [K8S,学习笔记,docker]
category: Kubernetes

---



## Centos7.3部署K8s 单节点

首先需要配置 yum 源：

```
cat >/etc/yum.repos.d/kubernetes.repo<<-EOF 
[virt7-docker-common-release] 
name=virt7-docker-common-release 
baseurl=http://cbs.centos.org/repos/virt7-docker-common-release/x86_64/os/ 
gpgcheck=0 
EOF
```

安装所需的包

```
yum -y install --enablerepo=virt7-docker-common-release kubernetes etcd
```



修改配置文件：/etc/sysconfig/docker

添加下列代码

```
ADD_REGISTRY='--add-registry reg.docker.lc'
```

修改配置文件 /etc/kubernetes/apiserver：

```
KUBE_API_ADDRESS="--insecure-bind-address=0.0.0.0"     #这里把127.0.0.1改成0.0.0.0 

KUBE_ADMISSION_CONTROL="--admission-control=NamespaceLifecycle,NamespaceExists,LimitRanger,Security 
ContextDeny,ResourceQuota"
```

去掉 ServiceAccount

```
KUBE_ADMISSION_CONTROL="--admission-control=NamespaceLifecycle,NamespaceExists,LimitRanger,Security
ContextDeny,ResourceQuota"
```

把服务添加到启动项，并启动服务：

```
for SERVICE in docker etcd kube-apiserver kube-controller-manager kube-scheduler kube-proxy kubelet; do  

    systemctl start $SERVICE 
    systemctl enable $SERVICE 

done
```



**注意：以上步骤来源于** [Centos7 单节点上安装kubernetes-dashboard过程](https://www.58jb.com/html/152.html )

以下部分源于部署时踩过的坑

升级系统 Centos系统, 不然可能会存在某些兼容性问题

```
yum update
```

安装完成后需重启docker

```
systemctl restart docker
```

**解决 docker pull** [registry.access.redhat.com/rhel7/pod-infrastructure:latest](http://registry.access.redhat.com/rhel7/pod-infrastructure:latest) 错误

```
yum install *rhsm* -y

wget http://mirror.centos.org/centos/7/os/x86_64/Packages/python-rhsm-certificates-1.19.10-1.el7_4.x86_64.rpm

rpm2cpio python-rhsm-certificates-1.19.10-1.el7_4.x86_64.rpm | cpio -iv --to-stdout ./etc/rhsm/ca/redhat-uep.pem | tee /etc/rhsm/ca/redhat-uep.pem
```



生成Yaml 文件

**注意：镜像最好先下载到本地，不然可能会出现错误，如Error或ImagePullBackOff**

```
kind: Deployment 
apiVersion: extensions/v1beta1 
metadata: 
  labels: 
    app: kubernetes-dashboard 
  name: kubernetes-dashboard 
  namespace: kube-system 
spec: 
  replicas: 1 
  selector: 
    matchLabels: 
      app: kubernetes-dashboard 
  template: 
    metadata: 
      labels: 
        app: kubernetes-dashboard 
      # Comment the following annotation if Dashboard must not be deployed on master 
      annotations: 
        scheduler.alpha.kubernetes.io/tolerations: | 
          [ 
            { 
              "key": "dedicated", 
              "operator": "Equal", 
              "value": "master", 
              "effect": "NoSchedule" 
            } 
          ] 
    spec: 
      containers: 
      - name: kubernetes-dashboard 
        image: docker.io/siriuszg/kubernetes-dashboard-amd64      #默认的镜像是使用google的，这里改成内网 
        imagePullPolicy: Always 
        ports: 
        - containerPort: 9090 
          protocol: TCP 
        args: 
          # Uncomment the following line to manually specify Kubernetes API server Host 
          # If not specified, Dashboard will attempt to auto discover the API server and connect 
          # to it. Uncomment only if the default does not work. 
          - --apiserver-host=http://172.24.54.206:8080    #注意这里是api的地址 
        livenessProbe: 
          httpGet: 
            path: / 
            port: 9090 
          initialDelaySeconds: 30 
          timeoutSeconds: 30 
--- 
kind: Service 
apiVersion: v1 
metadata: 
  labels: 
    app: kubernetes-dashboard 
  name: kubernetes-dashboard 
  namespace: kube-system 
spec: 
  type: NodePort 
  ports: 
  - port: 80 
    targetPort: 9090 
  selector: 
    app: kubernetes-dashboard 

```



创建实例

```
Kubectl create -f kubernetes-dashboard.yaml
```



http://IP:8080/api/v1/proxy/namespaces/kube-system/services/kubernetes-dashboard/#!/namespace?namespace=default