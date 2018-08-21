# ATEM Vision Switcher Libary Development Branch

Currently in development created by Hayden Donald.

This is a C# libary for the Black Magic Design ATEM Live Production Switchers. This project aims to allow developers to use the ATEM SDK more easily with this
API doing most of the backend processing.

#### This Branch Is Most Likley Buggy! Use The Release Branch

## Current Support
The project is currently not tested. It is however being developed with a ATEM ME2

## Planned Support
- Project currently on hold as i'm using Node Red to control our system now. Most of it works as far as i remember, feel free to post any issues you find so if i ever pick it up again i can remember what i was doing :)

## Known Issues
There seems to be a issue casting a COM object, however i think its only when sending a command while recieving. Example: You add a event to be called when the program input changes to change the program input. This causes the error.

## API Information


#### ATEM_Switcher Object
| Name | Desciption | Return | Tested
|---------|----------|----------|----------|
| Connect(String ipAddress) | Attempt Connection To The Switcher | ATEM_VisionSwitcher.Status | Working |

Not Complete.

#### MixEffectBlocks Object
| Name | Desciption | Return | Tested
|---------|----------|----------|----------|
|  |  |  |  |

Not Complete.


#### Keyers Object
| Name | Desciption | Return | Tested
|---------|----------|----------|----------|
|  |  |  |  |

Not Complete.

## Using The API
To use the API download the development DLL from /bin/debug and include it in your references of your solution

#### Using Visual Studio
Right Click References -> Browse -> Select the downloaded dll

## Development Notes
#### Done
| Object | Tested |
|---------|----------|
| DownstreamKeyer  | No | 
| UpstreamKeyer  | No | 
| Keyers  | No | 
| Keyer  | No | 
| Input  | No | 
| SwitcherInput  | 
| AuxInput  |
| DebugConsole  | Yes |
| DownstreamKeyerMonitor  | No |
| UpstreamKeyerMonitor  | No |
| MixEffectBlockMonitor  | No |
| SwitcherInputMonitor  | No |
| AuxInputMonitor  | No |
| Inputs | No |
