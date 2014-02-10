mkdir ..\Packages\Units\lib
mkdir "..\Packages\Units\lib\portable-net4+sl4+wp71+win8"

copy ..\Output\PCL\Units.* "..\Packages\Units\lib\portable-net4+sl4+wp71+win8"
copy ..\License.txt ..\Packages\Units

set EnableNuGetPackageRestore=true
..\Tools\NuGet\NuGet.exe pack ..\Packages\Units\Units.nuspec -OutputDirectory ..\Packages > pack.log
