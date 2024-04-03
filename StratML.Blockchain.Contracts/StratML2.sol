// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;
import "@openzeppelin/contracts/access/Ownable.sol";
enum ReportType{
    StrategticPlan,
    PerfomancePlan,
    PerfomanceReport
}
enum RoleType{
    Performer,
    Beneficiary
}
enum StakeholderType{
    Person,
    Organization,
    GenericGroup
}
enum PerfomanceIndicatorType{
    Quantitative,
    Qualitative
}
enum RelationshipType{
    BroaderThan,
    PeerTo,
    NarrowerThan
}
enum ValueChainStageType{
    Outcome,
    OutputProcessing,
    Output,
    InputProcessing,
    Input
}
struct RoleResponseBase{
    string name;
    string description;
    RoleType roleType;
    address[] stakeholders;
}
struct RoleResponse{
    RoleResponseBase base;
    StakeholderResponseBase[] stakeholders;
}
struct StakeholderResponseBase{
    string name;
    StakeholderType stakeholderType;
    address[] roles;
}
struct StakeholderResponse{
    StakeholderResponseBase base;
    RoleResponseBase[] roles;
}
contract Role is Ownable {
    string public name;
    string public description;
    RoleType public roleType;
    address[] stakeholders;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(string memory _name, string memory _description, RoleType _roleType) Ownable(msg.sender){
        name = _name;
        description = _description;
        roleType = _roleType;
    }
    function updateRole(string memory _name, string memory _description, RoleType _roleType) public onlyOwner{
        name = _name;
        description = _description;
        roleType = _roleType;
    }
    function addStakeholder(address _stakeholderAddress) public onlyOwner{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                return;
            }
        }
        stakeholders.push(_stakeholderAddress);
        emit StakeholderAdded(_stakeholderAddress);
    }
    function removeStakeholder(address _stakeholderAddress) public onlyOwner{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                stakeholders[i] = stakeholders[stakeholders.length - 1];
                stakeholders.pop();
                break;
            }
        }
    }
    function getRole() public view returns(RoleResponse memory){
        RoleResponse memory response;
        response.base.name = name;
        response.base.description = description;
        response.base.roleType = roleType;
        response.base.stakeholders = stakeholders;
        response.stakeholders = new StakeholderResponseBase[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i].name = stakeholder.name();
            response.stakeholders[i].stakeholderType = stakeholder.stakeholderType();
            response.stakeholders[i].roles = stakeholder.getRoles();
        }
        return response;
    }
    function getStakeholderAddresses() public view returns(address[] memory){
        return stakeholders;
    }
}
contract Stakeholder is Ownable {
    string public name;
    StakeholderType public stakeholderType;
    address[] public roles; // Changed from a single address to an array

    constructor(string memory _name, StakeholderType _stakeholderType, address[] memory _roles) Ownable(msg.sender) {
        name = _name;
        stakeholderType = _stakeholderType;
        roles = _roles;

        // Delegatecall to addStakeholder in each Role contract
        for(uint i = 0; i < _roles.length; i++) {
            (bool success, ) = _roles[i].delegatecall(
                abi.encodeWithSignature("addStakeholder(address)", address(this))
            );
            require(success, "Delegatecall to addStakeholder failed");
        }
    }

    function updateStakeholder(string memory _name, StakeholderType _stakeholderType, address[] memory _newRoles) public onlyOwner {
        name = _name;
        stakeholderType = _stakeholderType;

        // Remove from old roles
        for(uint i = 0; i < roles.length; i++) {
            (bool removeSuccess, ) = roles[i].delegatecall(
                abi.encodeWithSignature("removeStakeholder(address)", address(this))
            );
            require(removeSuccess, "Delegatecall to removeStakeholder failed");
        }

        // Add to new roles
        for(uint i = 0; i < _newRoles.length; i++) {
            (bool addSuccess, ) = _newRoles[i].delegatecall(
                abi.encodeWithSignature("addStakeholder(address)", address(this))
            );
            require(addSuccess, "Delegatecall to addStakeholder failed");
        }

        roles = _newRoles;
    }

    function getStakeholder() public view returns(StakeholderResponse memory){
        StakeholderResponse memory response;
        response.base.name = name;
        response.base.stakeholderType = stakeholderType;
        response.base.roles = roles;
        response.roles = new RoleResponseBase[](roles.length);
        for(uint i = 0; i < roles.length; i++){
            Role role = Role(roles[i]);
            response.roles[i].name = role.name();
            response.roles[i].description = role.description();
            response.roles[i].roleType = role.roleType();
            response.roles[i].stakeholders = role.getStakeholderAddresses();
        }
        return response;
    }
    function getRoles() public view returns(address[] memory){
        return roles;
    }
}