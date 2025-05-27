# Temporary symlinks manager solution
```
      _   _           _          
   __| | (_)  _ __   | | __      DIrectory temporary lINKs manager
  / _` | | | | '_ \  | |/ /      
 | (_| | | | | | | | |   <       by @ejjonatah              5.2025
  \__,_| |_| |_| |_| |_|\_\
```
The project is not necessary what the title implies. I stepped upon a problem dealing with onedrive which goes as 
follows. Its hard to deal with caching when OneDrive is present due to the fact that is not possible to 
easily ignore specific directory name that will be filled with sometimes tons of cached files (that are easily recreatable like 
.vs/, node_modules and more)

> How will I solve this? Using symbolic links! (Directory junctions) which are ignored by onedrive by default.