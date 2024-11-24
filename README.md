# HashBrowns

[![.NET Publish](https://github.com/JaCraig/HashBrowns/actions/workflows/dotnet-publish.yml/badge.svg)](https://github.com/JaCraig/HashBrowns/actions/workflows/dotnet-publish.yml)

HashBrowns is a library to help simplify encryption within .Net.

## Basic Usage

To use the library you first need to set up things on the ServiceCollection. Thankfully this only takes one call to do:

    serviceCollection.RegisterHashBrowns();
					
This is required prior to using the CryptoManager or extension methods class for the first time. Once it is set up, you can use the CryptoManager class after getting an instance from the IoC container:

    var Instance = cryptoManagerInstance.Encrypt(...);
	
However instead of having the IoC container create the class, you can also use the extension methods found in the HashBrowns namespace:

    var EncryptedData = "My string that I want to encrypt".Encrypt(Key, Salt, HashingAlgorithm, NumberIterations, InitialVector, KeySize, EncryptionAlgorithm);

Similarly you can decrypt:

    var DecryptedData = EncryptedData.Decrypt(Key, Salt, HashingAlgorithm, NumberIterations, InitialVector, KeySize, EncryptionAlgorithm);

Also hashing is available:

    var MyHashedValue = "Example data".Hash(HashingAlgorithm);

## Installation

The library is available via Nuget with the package name "HashBrowns". To install it run the following command in the Package Manager Console:

Install-Package HashBrowns
