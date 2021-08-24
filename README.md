# Parallel File Divider (splitter and joiner)


## Why more?
Of course, there are already a lot of tools and utils providing similar or even more features. Some of those provide opportunity to verify output file checksum. Others give a flexible way to name part files. But I haven't found any of those that provide user opportunity to configure parallel threads for joining or division.

## Why is it useful?
In case if you have a fat32 storage device, which you can't qickly format to ntfs, but still need to store some big files in it. You will need this portable application at least in the PC you take this file from.

## How to work with it?
On the first tab you can select file you want to divide and a folder, which you want to use as a destination for splitted files. Apart of that, you can select amount of parallel threads that you want to use to split this file.
It is supposed, that you use this folder on the PC you take some big file from.

![Divide tab](https://sun9-71.userapi.com/impg/BtXrYtE19DgZwjASiBSU_KaPM-r4Y_2nXYXXrQ/QXQ_4ZfUGhg.jpg?size=771x684&quality=96&sign=52d53d2d954949aa0ffb20752d68ee0b&type=album)


On the second tab, you can select which folder contains splitted files and then the file name you want to join these files into.
This tab is supposed to be used on PC you want to move your big file to.

![Join tab](https://sun9-83.userapi.com/impg/CO-2m-H4a1XRpTYjl5D3YGyGCyFEnUqt7mOuxg/k7dNM4ow1PM.jpg?size=771x684&quality=96&sign=8f76b6a5830c71e66a5cd1eb4d2f0ea5&type=album)


During the execution of the process, progress widow is displayed. If you selected several threads, you can watch progress of each of them. If you figured out something is wrong or changed your mind, you can cancel the operation.

![Progress window](https://sun9-47.userapi.com/impg/1sdi_ND4i_C-9AlSARcTTonrtwTvAvtdgCtKig/m4Zpkam_upM.jpg?size=786x550&quality=96&sign=9c605e99579cc3ed960f79f3b559e25a&type=album)


## Thats it
If you have any suggestions or noticed some bugs feel free to create new issues
