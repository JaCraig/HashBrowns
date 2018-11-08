# HashBrowns

[![Build status](https://ci.appveyor.com/api/projects/status/0e9q4k7van5qv3w3?svg=true)](https://ci.appveyor.com/project/JaCraig/hashbrowns)

HashBrowns is a library to help simplify encryption within .Net.

## Basic Usage

The system relies on an IoC wrapper called [Canister](https://github.com/JaCraig/Canister). While Canister has a built in IoC container, it's purpose is to actually wrap your container of choice in a way that simplifies setup and usage for other libraries that don't want to be tied to a specific IoC container. HashBrowns uses it to detect and pull in various info. As such you must set up Canister in order to use HashBrowns:

    Canister.Builder.CreateContainer(new List<ServiceDescriptor>())
                    .RegisterHashBrowns()
                    .Build();
					
This is required prior to using the CryptoManager or extension methods class for the first time. Once Canister is set up, you can use the CryptoManager class:

    var Instance = Canister.Builder.Bootstrapper.Resolve<CryptoManager>().Encrypt(...);
	
However instead of having the IoC container create the class, you can also use the extension methods found in the HashBrowns namespace:

    var EncryptedData = "My string that I want to encrypt".Encrypt(Key, Salt, HashingAlgorithm, NumberIterations, InitialVector, KeySize, EncryptionAlgorithm);

Similarly you can decrypt:

    var DecryptedData = EncryptedData.Decrypt(Key, Salt, HashingAlgorithm, NumberIterations, InitialVector, KeySize, EncryptionAlgorithm);

Also hashing is available:

    var MyHashedValue = "Example data".Hash(HashingAlgorithm);

## Installation

The library is available via Nuget with the package name "HashBrowns". To install it run the following command in the Package Manager Console:

Install-Package HashBrowns
