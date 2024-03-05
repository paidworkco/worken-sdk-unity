<p align="center">
  <img src="https://zrcdn.net/images/logos/paidwork/paidwork-logo-header-mobile-bitlabs.png" alt="Paidwork" />
</p>

<h3 align="center">
  Send & Receive secure Blockchain transactions with Worken
</h3>
<p align="center">
  🚀 Over 15M+ Users using <a href="https://www.paidwork.com/?utm_source=github.com&utm_medium=referral&utm_campaign=readme">WORK!</a>
</p>

<p align="center">
  <a href="https://github.com/paidworkco/worken-sdk-php">
    <img alt="GitHub Repository Stars Count" src="https://img.shields.io/github/stars/paidworkco/worken-sdk-php?style=social" />
  </a>
    <a href="https://x.com/paidworkco">
        <img alt="Follow Us on X" src="https://img.shields.io/twitter/follow/paidworkco?style=social" />
    </a>
</p>
<p align="center">
    <a href="http://commitizen.github.io/cz-cli/">
        <img alt="Commitizen friendly" src="https://img.shields.io/badge/commitizen-friendly-brightgreen.svg" />
    </a>
    <a href="https://github.com/paidworkco/worken-sdk-php">
        <img alt="License" src="https://img.shields.io/github/license/paidworkco/worken-sdk-php" />
    </a>
    <a href="https://github.com/paidworkco/worken-sdk-php/pulls">
        <img alt="PRs Welcome" src="https://img.shields.io/badge/PRs-welcome-brightgreen.svg" />
    </a>
</p>

SDK library providing access to make easy and secure Blockchain transactions with Worken

## Account object usage
#### Initialization
```csharp
using worken_sdk_unity.AccountMenager;
AccountManager account = new AccountManager(); // Create account object
```
### Methods
#### GetBalanceInEtherWei
```csharp
account.GetBalanceInEtherWei(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. Your wallet address |

#### Description
Returns the balance in ether in WEI format


#### GetBalanceInEther
```csharp
account.GetBalanceInEther(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. Your wallet address |

#### Description
Returns the balance in ether


#### GetBalanceInWorkenWei
```csharp
account.GetBalanceInWorkenWei(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. Your wallet address |

#### Description
Returns the balance in Worken in WEI format


#### GetBalanceInWorken
```csharp
account.GetBalanceInWorken(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. Your wallet address |

#### Description
Returns the balance in Worken


#### GetBalanceInWorkenHex
```csharp
account.GetBalanceInWorkenHex(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. Your wallet address |

#### Description
Returns the balance in Worken in hexadecimal format


#### GetBalanceInWorkenHex
```csharp
account.GetBalanceInEtherHex(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. Your wallet address |

#### Description
Returns the balance in Ether in hexadecimal format


#### CreateAccount
```csharp
account.CreateAccount(address);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `privateKey` | `string` | **Required**. your private key |

#### Description
Creates an account object based on a private key
## Network object usage
#### Initialization
```csharp
using worken_sdk_unity.NetworkManager;
NetworkManager network = new NetworkManager(); // Create network object
```
### Methods
#### GetLatestBlock
```csharp
network.GetLatestBlock();
```

#### Description
Returns the number of the latest block in the network.


#### GetHashRate
```csharp
network.GetHashRate();
```

#### Description
Returns the network hash rate.


### GasPrice
```csharp
network.GasPrice();
```

#### Description
Returns the Gas price.


#### getBlockInformation
```csharp
network.getBlockInformation(blockNumber,apiKeyToken);
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `blockNumber` | `int` | **Required**. block number |
| `apiKeyToken` | `string` | **Required**. apiKeyToken |

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `blockHex` | `string` | **Required**. block number in hex |
| `apiKeyToken` | `string` | **Required**. apiKeyToken |

#### Description
Method retrieves block information.
## Transactions object usage
#### Initialization
```csharp
using worken_sdk_unity.Transactions;
using worken_sdk_unity.Account;

var account = accountManager.CreateAccount(address);
//or
var walletManager = new WalletManager();
var wallet = wallet.CreateWallet();
var account = wallet.GetAccount(0);
//get account from created wallet object by index
```
### Methods
#### SendTransaction
```csharp
account.SendTransaction(to,amount)
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `to` | `string` | **Required**. addres of receiver |
| `amount` | `Nethereum.Hex.HexTypes.HexBigInteger` | **Required**. amount to send |


#### Description
This method allows sending a transaction from the 'account' to the recipient 'To' specifying the value 'amount'.


#### GetTransactionStatus
```csharp
account.GetTransactionStatus(transactionHash)
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `transactionHash` | `string` | **Required**. transaction Hash|


#### Description
Returns the status of the transaction with the specified 'TransactionHash'.


#### GetRecentTransactions
```csharp
account.GetRecentTransactions(blockNumber)
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `blockNumber` | `ulong` | **Required**. block blockNumber|


#### Description
Returns all transactions for the specified block number.
## Wallet object usage
#### Initialization
```csharp
using worken_sdk_unity.WalletMenager;

var walletManager = new WalletManager();

```
### Methods
#### CreateWallet
```csharp
walletManager.CreateWallet()
```
#### Description
This method is responsible for creating a Wallet object required for further operations.with default 12 words and as default language English

```csharp
walletManager.CreateWallet(wordCount)
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `wordCount` | `NBitcoin.WordCount` | **Required**. wordCount |
| `wordlist` | `NBitcoin.Wordlist` | **Required**. wordlist |


#### Description
This method is responsible for creating a Wallet object required for further operations.based on provided enum and provided language 


#### GetWalletHistory
```csharp
walletManager.GetWalletHistory(address,apiKey)
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `address` | `string` | **Required**. address |
| `apiKey` | `string` | **Required**. apiKey |


#### Description
Method retrieves up to 10000 records of wallet history under the address 'address' using the key 'apiKey'
More Details: https://docs.polygonscan.com/api-endpoints/accounts#get-a-list-of-internal-transactions-by-address

### ExtensionsMethods

#### GetNextAccountNonce
```csharp
account.GetNextAccountNonce()
```
#### Description
Returns the nonce


## Contract object usage
#### Initialization
```csharp
using worken_sdk_unity.Contract;

var contract = new ContractManager();
```

### Methods
#### GetContractStatus
```csharp
contract.GetContractStatus()
```
#### Description
Returnes true if contract is active
