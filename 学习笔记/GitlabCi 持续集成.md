本文学习文章：
https://yq.aliyun.com/articles/686280


踩坑重点：
在gitlab 中的个人仓库设置 选择Ci/CD => Runner =》 共享Runner =》 禁用共享Runner
因为共享的Runner 默认使用ruby 2.5 的镜像环境 如果你使用不是ruby 可以直接禁用该共享

