[TOC]

# c#对象管理
原方案是用一个dictionary, 存储object对应的userdata, 维护一个1v1的关系. 每当有已存在object需要传给lua的时候, 就从dictinary里面找到对应的userdata. lua那边gc的时候, 如果没有引用了, 则从dictionary里面把对应的项删除.

这个方案总体而言挺不错的, 安全有效. 达到了数据传输, 以及释放的目标.

在这里有一些想法, 不一定比原来的好, 试验性质的做一些尝试.

## 方案


