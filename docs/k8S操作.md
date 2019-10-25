
Journalctl -f

测试命令：
microk8s.kubectl get all --all-namespaces | grep service/kubernetes-dashboard

#查看版本信息
kubectl version

#获取所有节点的信息
kubectl get nodes

Kubectl get pods --all-namespaces

#运行
kubectl run kubernetes-bootcamp --image=jocatalin/kubernetes-bootcamp:v1 --port=8080

#查看当前节点所有的 deployments
kubectl get deployments

#查看pods 信息
kubectl get pods

Ps: STATUS：ImagePullBackOff 镜像拉取失败
#查看pods更多的信息
kubectl get pods -o wide

node IP 为172.24.54.206 
查看指定容器是否运行

发现缺少容器运行 使用journalctl -f 命令查看系统日志 异常原因：镜像名错误
#删除deployments
kubectl delete deployments  kubernetes-bootcamp 
矫正镜像名后重新生成 并查看

当前状态为 ContainerCreating 正在创建容器 状态为Running 则正常运行
PS：国内拉取镜像时间较长，且一定几率拉取失败


#查看deploy 的详细信息
kubectl describe deploy kubernetes-bootcamp



#在本机增添一个8001的端口
kubectl proxy



新开页面，使用curl 进行访问测试

Kubernetes-bootcamp-6b7849c495-6852l 

#扩充容
kubectl scale deploy kubernetes-bootcamp --replicas=4 





PS： 扩容会尽量平均分配在多台机器上 

#更新镜像
 kubectl set image deploy kubernetes-bootcamp kubernetes-bootcamp=jocatalin/kubernetes-bootcamp:v2
deployment "kubernetes-bootcamp" image updated



kubectl rollout status deploy kubernetes-bootcamp




#回滚
Kubectl rollout  undo deploy kuberbetes-bootcamp
