# ATEM Vision Switcher Libary Development Branch

Currently in development created by Hayden Donald.

This is a C# libary for the Black Magic Design ATEM Live Production Switchers. This project aims to allow developers to use the ATEM SDK more easily with this
API doing most of the backend processing.

####This Branch Is Most Likley Buggy! Use The Release Branch

##Current Support
The project is currently not tested. It is however being developed with a ATEM ME2

##Planned Support
Alot of features!

##Known Issues
There seems to be a issue casting a COM object, however i think its only when sending a command while recieving. Example: You add a event to be called when the program input changes to change the program input. This causes the error.

##API Information


####ATEM_Switcher Object
| Name | Desciption | Return | Tested
|---------|----------|----------|----------|
| Connect(String ipAddress) | Attempt Connection To The Switcher | ATEM_VisionSwitcher.Status | Working |

Not Complete.

####MixEffectBlocks Object
| Name | Desciption | Return | Tested
|---------|----------|----------|----------|
|  |  |  |  |

Not Complete.


####Keyers Object
| Name | Desciption | Return | Tested
|---------|----------|----------|----------|
|  |  |  |  |

Not Complete.


##Using The API
To use the API download the development DLL from /bin/debug and include it in your references of your solution

####Using Visual Studio
Right Click References -> Browse -> Select the downloaded dll
