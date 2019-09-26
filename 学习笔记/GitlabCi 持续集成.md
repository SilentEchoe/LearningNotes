
本文学习文章：
https://yq.aliyun.com/articles/686280


踩坑重点：
在gitlab 中的个人仓库设置 选择Ci/CD => Runner =》 共享Runner =》 禁用共享Runner
因为共享的Runner 默认使用ruby 2.5 的镜像环境 如果你使用不是ruby 可以直接禁用该共享



DockerFile 的编写



.gitlab-ci.yml 的编写

variables:
  GIT_STRATEGY: none
stages:
  - test
test_job:
  stage: test
  only: 
    - master
  script:
    # 打开存放项目的路径
    - cd /home/gitproject 
    # 删除上次项目打包生成的文件
    - rm -rf /home/gitproject/gitrunner 
    - git clone 仓库地址
    - cd ./gitrunner
    # 根据配置编译生成
    - dotnet build --configuration Release 
    - rm -rf /home/project/gitrunner
    # 暂停容器
    - docker stop gitci
    # 删除上个版本的容器
    - docker rm gitci
    # 删除镜像
    - docker rmi gitciimages
    # 将项目发布到指定目录
    - dotnet publish -c Release --output /home/project/gitrunner
    # 打开指定目录
    - cd /home/project/gitrunner
    # 使用dockerfile 生成新的镜像
    - docker build -t gitciimages .
    # 将文件拷贝到镜像内 并生成容器 
    - docker run -d -v /home/project/gitrunner:/code -p 5000:5000 --name gitci --restart always gitciimages