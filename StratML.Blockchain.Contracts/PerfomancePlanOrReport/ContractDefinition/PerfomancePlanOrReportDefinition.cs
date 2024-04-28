using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace StratML.Contracts.PerfomancePlanOrReport.ContractDefinition
{


    public partial class PerfomancePlanOrReportDeployment : PerfomancePlanOrReportDeploymentBase
    {
        public PerfomancePlanOrReportDeployment() : base(BYTECODE) { }
        public PerfomancePlanOrReportDeployment(string byteCode) : base(byteCode) { }
    }

    public class PerfomancePlanOrReportDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801562000010575f80fd5b5060405162003025380380620030258339810160408190526200003391620001f5565b33806200005957604051631e4fbdf760e01b81525f600482015260240160405180910390fd5b6200006481620000e5565b50600180546001600160a01b0319166001600160a01b03871617905560026200008e858262000341565b5060036200009d848262000341565b50600b805483919060ff60a01b1916600160a01b836002811115620000c657620000c66200040d565b02179055506004620000d9828262000341565b50505050505062000421565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b5f52604160045260245ffd5b5f82601f83011262000158575f80fd5b81516001600160401b038082111562000175576200017562000134565b604051601f8301601f19908116603f01168101908282118183101715620001a057620001a062000134565b8160405283815260209250866020858801011115620001bd575f80fd5b5f91505b83821015620001e05785820183015181830184015290820190620001c1565b5f602085830101528094505050505092915050565b5f805f805f60a086880312156200020a575f80fd5b85516001600160a01b038116811462000221575f80fd5b60208701519095506001600160401b03808211156200023e575f80fd5b6200024c89838a0162000148565b9550604088015191508082111562000262575f80fd5b6200027089838a0162000148565b9450606088015191506003821062000286575f80fd5b6080880151919350808211156200029b575f80fd5b50620002aa8882890162000148565b9150509295509295909350565b600181811c90821680620002cc57607f821691505b602082108103620002eb57634e487b7160e01b5f52602260045260245ffd5b50919050565b601f8211156200033c57805f5260205f20601f840160051c81016020851015620003185750805b601f840160051c820191505b8181101562000339575f815560010162000324565b50505b505050565b81516001600160401b038111156200035d576200035d62000134565b62000375816200036e8454620002b7565b84620002f1565b602080601f831160018114620003ab575f8415620003935750858301515b5f19600386901b1c1916600185901b17855562000405565b5f85815260208120601f198616915b82811015620003db57888601518255948401946001909101908401620003ba565b5085821015620003f957878501515f19600388901b60f8161c191681555b505060018460011b0185555b505050505050565b634e487b7160e01b5f52602160045260245ffd5b612bf6806200042f5f395ff3fe608060405234801561000f575f80fd5b50600436106101a1575f3560e01c8063715018a6116100f35780638da5cb5b116100935780639f8ecfe11161006e5780639f8ecfe11461035e578063d68287df14610371578063dff9067514610384578063f2fde38b14610399575f80fd5b80638da5cb5b146103315780639754a3a8146103415780639e656d6914610356575f80fd5b80637ac90722116100ce5780637ac90722146102cd5780637b103999146102e05780638883ee8c1461030b5780638b3526e31461031e575f80fd5b8063715018a6146102b55780637284e416146102bd57806374516ad2146102c5575f80fd5b80632768e6d31161015e57806355fde32d1161013957806355fde32d1461026957806359e67f8e1461027c5780636ff2c6101461028f57806370504b78146102a2575f80fd5b80632768e6d31461022c57806332fa92b2146102415780634d04548d14610254575f80fd5b806303f98812146101a557806306fdde03146101c357806319eb4a90146101d85780631b28f5e1146101ed5780631fc888481461020257806324335b7914610217575b5f80fd5b6101ad6103ac565b6040516101ba9190611a76565b60405180910390f35b6101cb610443565b6040516101ba9190611a8f565b6101e06104cf565b6040516101ba9190611aa1565b6101f561064d565b6040516101ba9190611c79565b61020a61099a565b6040516101ba9190611f4c565b61021f610c5c565b6040516101ba91906120ae565b61023f61023a3660046120fa565b610c88565b005b61023f61024f366004612115565b610d30565b61025c610e26565b6040516101ba919061212c565b61023f6102773660046120fa565b611151565b61023f61028a3660046120fa565b611190565b61023f61029d3660046120fa565b6111cf565b61023f6102b03660046120fa565b6112d0565b61023f6113a9565b6101cb6113bc565b6101cb6113c9565b61023f6102db366004612266565b6113d6565b6001546102f3906001600160a01b031681565b6040516001600160a01b0390911681526020016101ba565b61023f6103193660046120fa565b611454565b61023f61032c3660046120fa565b611493565b5f546001600160a01b03166102f3565b6103496114d2565b6040516101ba91906122c5565b610349611532565b61023f61036c366004612311565b611593565b61023f61037f3660046120fa565b611627565b61038c6116cd565b6040516101ba9190612378565b61023f6103a73660046120fa565b61175f565b6103b4611819565b600a546001600160a01b03166103c8575f80fd5b600a5f9054906101000a90046001600160a01b03166001600160a01b031663812d0bc06040518163ffffffff1660e01b81526004015f60405180830381865afa158015610417573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f1916820160405261043e91908101906123dc565b905090565b6002805461045090612476565b80601f016020809104026020016040519081016040528092919081815260200182805461047c90612476565b80156104c75780601f1061049e576101008083540402835291602001916104c7565b820191905f5260205f20905b8154815290600101906020018083116104aa57829003601f168201915b505050505081565b60606006600201805480602002602001604051908101604052809291908181526020015f905b82821015610644578382905f5260205f2090600202016040518060400160405290815f8201805461052590612476565b80601f016020809104026020016040519081016040528092919081815260200182805461055190612476565b801561059c5780601f106105735761010080835404028352916020019161059c565b820191905f5260205f20905b81548152906001019060200180831161057f57829003601f168201915b505050505081526020016001820180546105b590612476565b80601f01602080910402602001604051908101604052809291908181526020018280546105e190612476565b801561062c5780601f106106035761010080835404028352916020019161062c565b820191905f5260205f20905b81548152906001019060200180831161060f57829003601f168201915b505050505081525050815260200190600101906104f5565b50505050905090565b61065561184d565b61065d61184d565b60058054806020026020016040519081016040528092919081815260200182805480156106b157602002820191905f5260205f20905b81546001600160a01b03168152600190910190602001808311610693575b50505091835250506006546001600160a01b03161561073e576006546040805163ce89188160e01b815290516001600160a01b039092169163ce891881916004808201925f929091908290030181865afa158015610711573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f19168201604052610738919081019061251e565b60208201525b6007546001600160a01b0316156107c35760075460408051630ce285e560e21b815290516001600160a01b039092169163338a1794916004808201925f929091908290030181865afa158015610796573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f191682016040526107bd919081019061251e565b60408201525b60088054604080516020808402820181019092528281529291905f9084015b82821015610931578382905f5260205f2090600202016040518060400160405290815f8201805461081290612476565b80601f016020809104026020016040519081016040528092919081815260200182805461083e90612476565b80156108895780601f1061086057610100808354040283529160200191610889565b820191905f5260205f20905b81548152906001019060200180831161086c57829003601f168201915b505050505081526020016001820180546108a290612476565b80601f01602080910402602001604051908101604052809291908181526020018280546108ce90612476565b80156109195780601f106108f057610100808354040283529160200191610919565b820191905f5260205f20905b8154815290600101906020018083116108fc57829003601f168201915b505050505081525050815260200190600101906107e2565b505050506060820152600980546040805160208084028201810190925282815292919083018282801561098b57602002820191905f5260205f20905b81546001600160a01b0316815260019091019060200180831161096d575b50505050506080820152919050565b6109a26118c2565b6109aa6118c2565b6109b261064d565b81526005546001600160401b038111156109ce576109ce61213e565b604051908082528060200260200182016040528015610a3957816020015b610a266040518060a001604052805f6001600160a01b03168152602001606081526020016060815260200160608152602001606081525090565b8152602001906001900390816109ec5790505b5060208201525f5b600554811015610afc575f60058281548110610a5f57610a5f61254f565b5f9182526020822001546040805163879bcf6960e01b815290516001600160a01b039092169350839263879bcf69926004808401938290030181865afa158015610aab573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f19168201604052610ad291908101906126f2565b83602001518381518110610ae857610ae861254f565b602090810291909101015250600101610a41565b506009546001600160401b03811115610b1757610b1761213e565b604051908082528060200260200182016040528015610b9057816020015b610b7d6040518060e001604052805f6001600160a01b031681526020016060815260200160608152602001606081526020016060815260200160608152602001606081525090565b815260200190600190039081610b355790505b5060408201525f5b600954811015610c56575f60066003018281548110610bb957610bb961254f565b5f91825260208220015460408051632aa9317560e11b815290516001600160a01b039092169350839263555262ea926004808401938290030181865afa158015610c05573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f19168201604052610c2c91908101906127c4565b83604001518381518110610c4257610c4261254f565b602090810291909101015250600101610b98565b50919050565b610c646118d5565b610c6c6118d5565b610c74610e26565b8152610c7e61099a565b6020820152919050565b610c9061179e565b5f5b600954811015610ce157816001600160a01b031660066003018281548110610cbc57610cbc61254f565b5f918252602090912001546001600160a01b031603610cd9575050565b600101610c92565b50600980546001810182555f919091527f6e1540171b6c0c960b71a7020d9f60077f6af931a8bbf590da0223dacf75c7af0180546001600160a01b0319166001600160a01b0383161790555b50565b610d3861179e565b6008548110610d5a57604051632d0483c560e21b815260040160405180910390fd5b600854610d69906001906128eb565b811015610de35760088054610d80906001906128eb565b81548110610d9057610d9061254f565b905f5260205f20906002020160066002018281548110610db257610db261254f565b5f918252602090912060029091020180610dcc8382612959565b50600181810190610ddf90840182612959565b5050505b6008805480610df457610df4612a2d565b5f828152602081205f1990920191600283020190610e1282826118fa565b610e1f600183015f6118fa565b5050905550565b610e2e611931565b610e36611931565b30815260028054610e4690612476565b80601f0160208091040260200160405190810160405280929190818152602001828054610e7290612476565b8015610ebd5780601f10610e9457610100808354040283529160200191610ebd565b820191905f5260205f20905b815481529060010190602001808311610ea057829003601f168201915b5050505050816020018190525060038054610ed790612476565b80601f0160208091040260200160405190810160405280929190818152602001828054610f0390612476565b8015610f4e5780601f10610f2557610100808354040283529160200191610f4e565b820191905f5260205f20905b815481529060010190602001808311610f3157829003601f168201915b5050505050816040018190525060048054610f6890612476565b80601f0160208091040260200160405190810160405280929190818152602001828054610f9490612476565b8015610fdf5780601f10610fb657610100808354040283529160200191610fdf565b820191905f5260205f20905b815481529060010190602001808311610fc257829003601f168201915b50505050508160600181905250610ff461064d565b6080820152600a546001600160a01b03161561108657600a5f9054906101000a90046001600160a01b03166001600160a01b031663812d0bc06040518163ffffffff1660e01b81526004015f60405180830381865afa158015611059573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f1916820160405261108091908101906123dc565b60a08201525b600b546001600160a01b03161561111357600b5f9054906101000a90046001600160a01b03166001600160a01b031663a14aba216040518163ffffffff1660e01b81526004015f60405180830381865afa1580156110e6573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f1916820160405261110d9190810190612a41565b60c08201525b600b5460e0820190600160a01b900460ff16600281111561113657611136611c8b565b9081600281111561114957611149611c8b565b905250919050565b61115961179e565b6006546001600160a01b03161561116e575f80fd5b600680546001600160a01b0319166001600160a01b0392909216919091179055565b61119861179e565b6007546001600160a01b0316156111ad575f80fd5b600780546001600160a01b0319166001600160a01b0392909216919091179055565b6111d761179e565b5f5b6005548110156112cc57816001600160a01b0316600582815481106112005761120061254f565b5f918252602090912001546001600160a01b0316036112c45760058054611229906001906128eb565b815481106112395761123961254f565b5f91825260209091200154600580546001600160a01b0390921691839081106112645761126461254f565b905f5260205f20015f6101000a8154816001600160a01b0302191690836001600160a01b0316021790555060058054806112a0576112a0612a2d565b5f8281526020902081015f1990810180546001600160a01b03191690550190555050565b6001016111d9565b5050565b6112d861179e565b5f5b6009548110156112cc57816001600160a01b0316600660030182815481106113045761130461254f565b5f918252602090912001546001600160a01b0316036113a1576009805461132d906001906128eb565b8154811061133d5761133d61254f565b5f91825260209091200154600980546001600160a01b0390921691839081106113685761136861254f565b5f91825260209091200180546001600160a01b0319166001600160a01b039290921691909117905560098054806112a0576112a0612a2d565b6001016112da565b6113b161179e565b6113ba5f6117ca565b565b6003805461045090612476565b6004805461045090612476565b6113de61179e565b6040805180820190915282815260208101829052600880546001810182555f9190915281516002919091027ff3f7a9fe364faab93b216da50a3214154f22a0a2b415b23a84c8169e8b636ee3019081906114389082612b07565b506020820151600182019061144d9082612b07565b5050505050565b61145c61179e565b600b546001600160a01b031615611471575f80fd5b600b80546001600160a01b0319166001600160a01b0392909216919091179055565b61149b61179e565b600a546001600160a01b0316156114b0575f80fd5b600a80546001600160a01b0319166001600160a01b0392909216919091179055565b6060600580548060200260200160405190810160405280929190818152602001828054801561152857602002820191905f5260205f20905b81546001600160a01b0316815260019091019060200180831161150a575b5050505050905090565b6060600660030180548060200260200160405190810160405280929190818152602001828054801561152857602002820191905f5260205f209081546001600160a01b0316815260019091019060200180831161150a575050505050905090565b61159b61179e565b60085483106115bd57604051632d0483c560e21b815260040160405180910390fd5b81600660020184815481106115d4576115d461254f565b905f5260205f2090600202015f0190816115ee9190612b07565b5080600660020184815481106116065761160661254f565b905f5260205f20906002020160010190816116219190612b07565b50505050565b61162f61179e565b5f5b60055481101561167d57816001600160a01b0316600582815481106116585761165861254f565b5f918252602090912001546001600160a01b031603611675575050565b600101611631565b50600580546001810182555f919091527f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db00180546001600160a01b0383166001600160a01b031990911617905550565b6116d561198e565b600b546001600160a01b03166116e9575f80fd5b600b5f9054906101000a90046001600160a01b03166001600160a01b031663a14aba216040518163ffffffff1660e01b81526004015f60405180830381865afa158015611738573d5f803e3d5ffd5b505050506040513d5f823e601f3d908101601f1916820160405261043e9190810190612a41565b61176761179e565b6001600160a01b03811661179557604051631e4fbdf760e01b81525f60048201526024015b60405180910390fd5b610d2d816117ca565b5f546001600160a01b031633146113ba5760405163118cdaa760e01b815233600482015260240161178c565b5f80546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6040518060a001604052805f6001600160a01b031681526020015f81526020015f81526020015f8152602001606081525090565b6040518060a001604052806060815260200161188460405180604001604052805f6001600160a01b03168152602001606081525090565b81526020016118ae60405180604001604052805f6001600160a01b03168152602001606081525090565b815260200160608152602001606081525090565b60405180606001604052806118ae61184d565b60405180604001604052806118e8611931565b81526020016118f56118c2565b905290565b50805461190690612476565b5f825580601f10611915575050565b601f0160209004905f5260205f2090810190610d2d91906119c5565b6040518061010001604052805f6001600160a01b0316815260200160608152602001606081526020016060815260200161196961184d565b8152602001611976611819565b815260200161198361198e565b81526020015f905290565b6040518060a001604052805f6001600160a01b03168152602001606081526020016060815260200160608152602001606081525090565b5b808211156119d9575f81556001016119c6565b5090565b5f5b838110156119f75781810151838201526020016119df565b50505f910152565b5f8151808452611a168160208601602086016119dd565b601f01601f19169290920160200192915050565b60018060a01b0381511682526020810151602083015260408101516040830152606081015160608301525f608082015160a06080850152611a6e60a08501826119ff565b949350505050565b602081525f611a886020830184611a2a565b9392505050565b602081525f611a8860208301846119ff565b5f60208083018184528085518083526040925060408601915060408160051b8701018488015f5b83811015611b1857888303603f1901855281518051878552611aec888601826119ff565b91890151858303868b0152919050611b0481836119ff565b968901969450505090860190600101611ac8565b509098975050505050505050565b5f815180845260208085019450602084015f5b83811015611b5e5781516001600160a01b031687529582019590820190600101611b39565b509495945050505050565b60018060a01b0381511682525f602082015160406020850152611a6e60408501826119ff565b5f815160a08452611ba360a0850182611b26565b905060208084015185830382870152611bbc8382611b69565b9250506040808501518684036040880152611bd78482611b69565b935050606085015186840360608801528381518086528486019150848160051b87010185840193505f5b82811015611c5157878203601f1901845284518051878452611c25888501826119ff565b91890151848303858b0152919050611c3d81836119ff565b968901969589019593505050600101611c01565b506080890151965089810360808b0152611c6b8188611b26565b9a9950505050505050505050565b602081525f611a886020830184611b8f565b634e487b7160e01b5f52602160045260245ffd5b60038110610d2d57634e487b7160e01b5f52602160045260245ffd5b5f82825180855260208086019550808260051b8401018186015f5b84811015611daa57858303601f19018952815180516001600160a01b0316845260e0858201518187870152611d0d828701826119ff565b91505060408083015186830382880152611d2783826119ff565b9250505060608083015186830382880152611d4283826119ff565b9250505060808083015186830382880152611d5d8382611b26565b9250505060a08083015186830382880152611d7883826119ff565b9250505060c08083015192508582038187015250611d968183611b26565b9a86019a9450505090830190600101611cd6565b5090979650505050505050565b5f815160608452611dcb6060850182611b8f565b60208481015186830387830152805180845292935081019181840191600582901b8501015f5b82811015611f2657601f1980878403018552855160018060a01b03808251168552602082015160a06020870152611e2b60a08701826119ff565b905060408301518682036040880152611e4482826119ff565b91505060608301518682036060880152611e5e82826119ff565b91505060808301519250858103608087015280835180835260208301915060208160051b8401016020860195505f5b82811015611f0457878583030184528651868151168352602081015160806020850152611ebd60808501826119ff565b90506040820151611ecd81611c9f565b80604086015250606082015191508381036060850152611eed8183611b26565b6020998a0199969096019593505050600101611e8d565b5080985050505050505050602085019450602084019350600181019050611df1565b50604087015194508781036040890152611f408186611cbb565b98975050505050505050565b602081525f611a886020830184611db7565b60018060a01b0381511682525f602082015160a06020850152611f8460a08501826119ff565b905060408301518482036040860152611f9d82826119ff565b91505060608301518482036060860152611fb782826119ff565b91505060808301518482036080860152611fd182826119ff565b95945050505050565b611fe381611c9f565b9052565b80516001600160a01b031682525f610100602083015181602086015261200f828601826119ff565b9150506040830151848203604086015261202982826119ff565b9150506060830151848203606086015261204382826119ff565b9150506080830151848203608086015261205d8282611b8f565b91505060a083015184820360a08601526120778282611a2a565b91505060c083015184820360c08601526120918282611f5e565b91505060e08301516120a660e0860182611fda565b509392505050565b602081525f8251604060208401526120c96060840182611fe7565b90506020840151601f19848303016040850152611fd18282611db7565b6001600160a01b0381168114610d2d575f80fd5b5f6020828403121561210a575f80fd5b8135611a88816120e6565b5f60208284031215612125575f80fd5b5035919050565b602081525f611a886020830184611fe7565b634e487b7160e01b5f52604160045260245ffd5b60405160a081016001600160401b03811182821017156121745761217461213e565b60405290565b604051608081016001600160401b03811182821017156121745761217461213e565b60405160e081016001600160401b03811182821017156121745761217461213e565b604051601f8201601f191681016001600160401b03811182821017156121e6576121e661213e565b604052919050565b5f6001600160401b038211156122065761220661213e565b50601f01601f191660200190565b5f82601f830112612223575f80fd5b8135612236612231826121ee565b6121be565b81815284602083860101111561224a575f80fd5b816020850160208301375f918101602001919091529392505050565b5f8060408385031215612277575f80fd5b82356001600160401b038082111561228d575f80fd5b61229986838701612214565b935060208501359150808211156122ae575f80fd5b506122bb85828601612214565b9150509250929050565b602080825282518282018190525f9190848201906040850190845b818110156123055783516001600160a01b0316835292840192918401916001016122e0565b50909695505050505050565b5f805f60608486031215612323575f80fd5b8335925060208401356001600160401b0380821115612340575f80fd5b61234c87838801612214565b93506040860135915080821115612361575f80fd5b5061236e86828701612214565b9150509250925092565b602081525f611a886020830184611f5e565b8051612395816120e6565b919050565b5f82601f8301126123a9575f80fd5b81516123b7612231826121ee565b8181528460208386010111156123cb575f80fd5b611a6e8260208301602087016119dd565b5f602082840312156123ec575f80fd5b81516001600160401b0380821115612402575f80fd5b9083019060a08286031215612415575f80fd5b61241d612152565b8251612428816120e6565b8082525060208301516020820152604083015160408201526060830151606082015260808301518281111561245b575f80fd5b6124678782860161239a565b60808301525095945050505050565b600181811c9082168061248a57607f821691505b602082108103610c5657634e487b7160e01b5f52602260045260245ffd5b5f604082840312156124b8575f80fd5b604051604081016001600160401b0382821081831117156124db576124db61213e565b81604052829350845191506124ef826120e6565b90825260208401519080821115612504575f80fd5b506125118582860161239a565b6020830152505092915050565b5f6020828403121561252e575f80fd5b81516001600160401b03811115612543575f80fd5b611a6e848285016124a8565b634e487b7160e01b5f52603260045260245ffd5b5f6001600160401b0382111561257b5761257b61213e565b5060051b60200190565b5f82601f830112612594575f80fd5b815160206125a461223183612563565b8083825260208201915060208460051b8701019350868411156125c5575f80fd5b602086015b848110156125ea5780516125dd816120e6565b83529183019183016125ca565b509695505050505050565b5f82601f830112612604575f80fd5b8151602061261461223183612563565b82815260059290921b84018101918181019086841115612632575f80fd5b8286015b848110156125ea5780516001600160401b0380821115612654575f80fd5b908801906080828b03601f190181131561266c575f80fd5b61267461217a565b87840151612681816120e6565b815260408481015184811115612695575f80fd5b6126a38e8b8389010161239a565b8a84015250606080860151600381106126ba575f80fd5b838301529285015192848411156126cf575f80fd5b6126dd8e8b86890101612585565b90830152508652505050918301918301612636565b5f60208284031215612702575f80fd5b81516001600160401b0380821115612718575f80fd5b9083019060a0828603121561272b575f80fd5b612733612152565b61273c8361238a565b815260208301518281111561274f575f80fd5b61275b8782860161239a565b602083015250604083015182811115612772575f80fd5b61277e8782860161239a565b604083015250606083015182811115612795575f80fd5b6127a18782860161239a565b6060830152506080830151828111156127b8575f80fd5b612467878286016125f5565b5f602082840312156127d4575f80fd5b81516001600160401b03808211156127ea575f80fd5b9083019060e082860312156127fd575f80fd5b61280561219c565b61280e8361238a565b8152602083015182811115612821575f80fd5b61282d8782860161239a565b602083015250604083015182811115612844575f80fd5b6128508782860161239a565b604083015250606083015182811115612867575f80fd5b6128738782860161239a565b60608301525060808301518281111561288a575f80fd5b61289687828601612585565b60808301525060a0830151828111156128ad575f80fd5b6128b98782860161239a565b60a08301525060c0830151828111156128d0575f80fd5b6128dc87828601612585565b60c08301525095945050505050565b8181038181111561290a57634e487b7160e01b5f52601160045260245ffd5b92915050565b601f82111561295457805f5260205f20601f840160051c810160208510156129355750805b601f840160051c820191505b8181101561144d575f8155600101612941565b505050565b818103612964575050565b61296e8254612476565b6001600160401b038111156129855761298561213e565b612999816129938454612476565b84612910565b5f601f8211600181146129ca575f83156129b35750848201545b5f19600385901b1c1916600184901b17845561144d565b5f8581526020808220868352908220601f198616925b83811015612a0057828601548255600195860195909101906020016129e0565b5085831015612a1d57818501545f19600388901b60f8161c191681555b5050505050600190811b01905550565b634e487b7160e01b5f52603160045260245ffd5b5f60208284031215612a51575f80fd5b81516001600160401b0380821115612a67575f80fd5b9083019060a08286031215612a7a575f80fd5b612a82612152565b612a8b8361238a565b8152602083015182811115612a9e575f80fd5b612aaa8782860161239a565b602083015250604083015182811115612ac1575f80fd5b612acd8782860161239a565b604083015250606083015182811115612ae4575f80fd5b612af08782860161239a565b60608301525060808301518281111561245b575f80fd5b81516001600160401b03811115612b2057612b2061213e565b612b2e816129938454612476565b602080601f831160018114612b61575f8415612b4a5750858301515b5f19600386901b1c1916600185901b178555612bb8565b5f85815260208120601f198616915b82811015612b8f57888601518255948401946001909101908401612b70565b5085821015612bac57878501515f19600388901b60f8161c191681555b505060018460011b0185555b50505050505056fea26469706673582212200cb7ece5758548cc82963259000007604f5483fba8da7ca14fd27f22764e3cb164736f6c63430008170033";
        public PerfomancePlanOrReportDeploymentBase() : base(BYTECODE) { }
        public PerfomancePlanOrReportDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_registry", 1)]
        public virtual string Registry { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 3)]
        public virtual string Description { get; set; }
        [Parameter("uint8", "_reportType", 4)]
        public virtual byte ReportType { get; set; }
        [Parameter("string", "_otherInformation", 5)]
        public virtual string OtherInformation { get; set; }
    }

    public partial class AddGoalFunction : AddGoalFunctionBase { }

    [Function("addGoal")]
    public class AddGoalFunctionBase : FunctionMessage
    {
        [Parameter("address", "_goalAddress", 1)]
        public virtual string GoalAddress { get; set; }
    }

    public partial class AddOrganizationFunction : AddOrganizationFunctionBase { }

    [Function("addOrganization")]
    public class AddOrganizationFunctionBase : FunctionMessage
    {
        [Parameter("address", "_organizationAddress", 1)]
        public virtual string OrganizationAddress { get; set; }
    }

    public partial class AddValueFunction : AddValueFunctionBase { }

    [Function("addValue")]
    public class AddValueFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 2)]
        public virtual string Description { get; set; }
    }

    public partial class DescriptionFunction : DescriptionFunctionBase { }

    [Function("description", "string")]
    public class DescriptionFunctionBase : FunctionMessage
    {

    }

    public partial class GetAdministrativeInformationFunction : GetAdministrativeInformationFunctionBase { }

    [Function("getAdministrativeInformation", typeof(GetAdministrativeInformationOutputDTO))]
    public class GetAdministrativeInformationFunctionBase : FunctionMessage
    {

    }

    public partial class GetGoalsFunction : GetGoalsFunctionBase { }

    [Function("getGoals", "address[]")]
    public class GetGoalsFunctionBase : FunctionMessage
    {

    }

    public partial class GetOrganizationsFunction : GetOrganizationsFunctionBase { }

    [Function("getOrganizations", "address[]")]
    public class GetOrganizationsFunctionBase : FunctionMessage
    {

    }

    public partial class GetPerfomancePlanOrReportResponseFunction : GetPerfomancePlanOrReportResponseFunctionBase { }

    [Function("getPerfomancePlanOrReportResponse", typeof(GetPerfomancePlanOrReportResponseOutputDTO))]
    public class GetPerfomancePlanOrReportResponseFunctionBase : FunctionMessage
    {

    }

    public partial class GetPerfomancePlanOrReportResponseBasedFunction : GetPerfomancePlanOrReportResponseBasedFunctionBase { }

    [Function("getPerfomancePlanOrReportResponseBased", typeof(GetPerfomancePlanOrReportResponseBasedOutputDTO))]
    public class GetPerfomancePlanOrReportResponseBasedFunctionBase : FunctionMessage
    {

    }

    public partial class GetStrategeticPlanCoreResponseFunction : GetStrategeticPlanCoreResponseFunctionBase { }

    [Function("getStrategeticPlanCoreResponse", typeof(GetStrategeticPlanCoreResponseOutputDTO))]
    public class GetStrategeticPlanCoreResponseFunctionBase : FunctionMessage
    {

    }

    public partial class GetStrategeticPlanCoreResponseBasedFunction : GetStrategeticPlanCoreResponseBasedFunctionBase { }

    [Function("getStrategeticPlanCoreResponseBased", typeof(GetStrategeticPlanCoreResponseBasedOutputDTO))]
    public class GetStrategeticPlanCoreResponseBasedFunctionBase : FunctionMessage
    {

    }

    public partial class GetValuesFunction : GetValuesFunctionBase { }

    [Function("getValues", typeof(GetValuesOutputDTO))]
    public class GetValuesFunctionBase : FunctionMessage
    {

    }

    public partial class GetsubmitterFunction : GetsubmitterFunctionBase { }

    [Function("getsubmitter", typeof(GetsubmitterOutputDTO))]
    public class GetsubmitterFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OtherInformationFunction : OtherInformationFunctionBase { }

    [Function("otherInformation", "string")]
    public class OtherInformationFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RegistryFunction : RegistryFunctionBase { }

    [Function("registry", "address")]
    public class RegistryFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveGoalFunction : RemoveGoalFunctionBase { }

    [Function("removeGoal")]
    public class RemoveGoalFunctionBase : FunctionMessage
    {
        [Parameter("address", "_goalAddress", 1)]
        public virtual string GoalAddress { get; set; }
    }

    public partial class RemoveOrganizationFunction : RemoveOrganizationFunctionBase { }

    [Function("removeOrganization")]
    public class RemoveOrganizationFunctionBase : FunctionMessage
    {
        [Parameter("address", "_organizationAddress", 1)]
        public virtual string OrganizationAddress { get; set; }
    }

    public partial class RemoveValueFunction : RemoveValueFunctionBase { }

    [Function("removeValue")]
    public class RemoveValueFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SetAdministrativeInformationFunction : SetAdministrativeInformationFunctionBase { }

    [Function("setAdministrativeInformation")]
    public class SetAdministrativeInformationFunctionBase : FunctionMessage
    {
        [Parameter("address", "_adminInfo", 1)]
        public virtual string AdminInfo { get; set; }
    }

    public partial class SetMissionFunction : SetMissionFunctionBase { }

    [Function("setMission")]
    public class SetMissionFunctionBase : FunctionMessage
    {
        [Parameter("address", "_mission", 1)]
        public virtual string Mission { get; set; }
    }

    public partial class SetsubmitterFunction : SetsubmitterFunctionBase { }

    [Function("setsubmitter")]
    public class SetsubmitterFunctionBase : FunctionMessage
    {
        [Parameter("address", "_submitter", 1)]
        public virtual string Submitter { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdateValueFunction : UpdateValueFunctionBase { }

    [Function("updateValue")]
    public class UpdateValueFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "_description", 3)]
        public virtual string Description { get; set; }
    }

    public partial class UpdateVisionFunction : UpdateVisionFunctionBase { }

    [Function("updateVision")]
    public class UpdateVisionFunctionBase : FunctionMessage
    {
        [Parameter("address", "_vision", 1)]
        public virtual string Vision { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class OutOfBoundsError : OutOfBoundsErrorBase { }
    [Error("OutOfBounds")]
    public class OutOfBoundsErrorBase : IErrorDTO
    {
    }

    public partial class OwnableInvalidOwnerError : OwnableInvalidOwnerErrorBase { }

    [Error("OwnableInvalidOwner")]
    public class OwnableInvalidOwnerErrorBase : IErrorDTO
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class OwnableUnauthorizedAccountError : OwnableUnauthorizedAccountErrorBase { }

    [Error("OwnableUnauthorizedAccount")]
    public class OwnableUnauthorizedAccountErrorBase : IErrorDTO
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }







    public partial class DescriptionOutputDTO : DescriptionOutputDTOBase { }

    [FunctionOutput]
    public class DescriptionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetAdministrativeInformationOutputDTO : GetAdministrativeInformationOutputDTOBase { }

    [FunctionOutput]
    public class GetAdministrativeInformationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual AdministrativeInformationResponse ReturnValue1 { get; set; }
    }

    public partial class GetGoalsOutputDTO : GetGoalsOutputDTOBase { }

    [FunctionOutput]
    public class GetGoalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetOrganizationsOutputDTO : GetOrganizationsOutputDTOBase { }

    [FunctionOutput]
    public class GetOrganizationsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetPerfomancePlanOrReportResponseOutputDTO : GetPerfomancePlanOrReportResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetPerfomancePlanOrReportResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual PerfomancePlanOrReportResponse ReturnValue1 { get; set; }
    }

    public partial class GetPerfomancePlanOrReportResponseBasedOutputDTO : GetPerfomancePlanOrReportResponseBasedOutputDTOBase { }

    [FunctionOutput]
    public class GetPerfomancePlanOrReportResponseBasedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual PerfomancePlanOrReportResponseBased ReturnValue1 { get; set; }
    }

    public partial class GetStrategeticPlanCoreResponseOutputDTO : GetStrategeticPlanCoreResponseOutputDTOBase { }

    [FunctionOutput]
    public class GetStrategeticPlanCoreResponseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual StrategeticPlanCoreResponse ReturnValue1 { get; set; }
    }

    public partial class GetStrategeticPlanCoreResponseBasedOutputDTO : GetStrategeticPlanCoreResponseBasedOutputDTOBase { }

    [FunctionOutput]
    public class GetStrategeticPlanCoreResponseBasedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual StrategeticPlanCoreResponseBased ReturnValue1 { get; set; }
    }

    public partial class GetValuesOutputDTO : GetValuesOutputDTOBase { }

    [FunctionOutput]
    public class GetValuesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<Value> ReturnValue1 { get; set; }
    }

    public partial class GetsubmitterOutputDTO : GetsubmitterOutputDTOBase { }

    [FunctionOutput]
    public class GetsubmitterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual ContactInformationResponse ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OtherInformationOutputDTO : OtherInformationOutputDTOBase { }

    [FunctionOutput]
    public class OtherInformationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RegistryOutputDTO : RegistryOutputDTOBase { }

    [FunctionOutput]
    public class RegistryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




















}
