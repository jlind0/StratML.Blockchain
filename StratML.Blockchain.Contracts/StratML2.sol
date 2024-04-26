// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;
import "@openzeppelin/contracts/access/Ownable.sol";
import "./BokkyPooBahsDateTimeLibrary.sol";
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
    None,
    Quantitative,
    Qualitative
}
enum RelationshipType{
    BroaderThan,
    PeerTo,
    NarrowerThan
}
enum ValueChainStageType{
    None,
    Outcome,
    OutputProcessing,
    Output,
    InputProcessing,
    Input
}
struct RoleResponseBased{
    address identifier;
    string name;
    string description;
    RoleType[] roleTypes;
    address[] stakeholders;
}
struct RoleResponse{
    RoleResponseBased base;
    StakeholderResponseBased[] stakeholders;
}
struct StakeholderResponseBased{
    address identifier;
    string name;
    StakeholderType stakeholderType;
    address[] roles;
}
struct StakeholderResponse{
    StakeholderResponseBased base;
    RoleResponseBased[] roles;
    string description;
}
struct Descriptor{
    string name;
    string value;
}
struct Decimal{
    int64 value;
    uint precision;
}
struct TargetResult{
    uint startDate;
    uint endDate;
    Decimal numberOfUnits;
    Descriptor descriptor;
    string description;
}
struct ActualResult{
    uint startDate;
    uint endDate;
    Decimal numberOfUnits;
    Descriptor descriptor;
    string description;
}
struct RelationshipResponse{
    address identifier;
    Reference[] references;
    string name;
    string description;
    RelationshipType relationshipType;
}
enum EntityTypes{
    Role,
    Stakeholder,
    PerformanceIndicator,
    Objective,
    Organization,
    Goal,
    Mission,
    Vision,
    Relationship
}
struct Reference{
    EntityTypes entityType;
    address identifier;
}
struct MeasurementInstance{
    ActualResult[] actualResults;
    TargetResult[] targetResults;
}
struct PermformanceIndicatorResponse{
    address identifier;
    string seqeunceIndicator;
    string measurementDimension;
    string unitOfMeasurement;
    RelationshipResponse[] relationships;
    MeasurementInstance[] measurementInstances;
    string otherInformation;
    ValueChainStageType vauleChangeStage;
    PerfomanceIndicatorType perfomanceIndicator;
}
struct ObjectiveResponseBased{
    address identifier;
    string name;
    string description;
    string sequenceIndicator;
    address[] stakeholders;
    string otherInformation;
    PermformanceIndicatorResponse[] perfomanceIndicators;
}
struct ObjectiveResponse{
    ObjectiveResponseBased base;
    StakeholderResponseBased[] stakeholders;
}
struct GoalResponseBased{
    address identifier;
    string name;
    string description;
    string sequenceIndicator;
    address[] stakeholders;
    string otherInformation;
    address[] objectives;
}
struct GoalResponse{
    GoalResponseBased base;
    StakeholderResponseBased[] stakeholders;
    ObjectiveResponseBased[] objectives;
}
struct OrganizationResponseBased{
    address identifier;
    string name;
    string description;
    string acryonym;
    StakeholderResponseBased[] stakeholders;
}
struct OrganizationResponse{
    OrganizationResponseBased base;
    StakeholderResponse[] stakeholders;
}
struct MissionResponse{
    address identifier;
    string description;
}
struct VisionResponse{
    address identifier;
    string description;
}
struct AdministrativeInformationResponse{
    address identifier;
    uint startDate;
    uint endDate;
    uint publicationDate;
    string source;
}
struct ContactInformationResponse{
    address identifier;
    string givenName;
    string surname;
    string phoneNumber;
    string emailAddress;
}
struct Value{
    string name;
    string description;
}
struct StrategeticPlanCoreResponseBased{
    address[] organizations;
    VisionResponse vision;
    MissionResponse mission;
    Value[] values;
    address[] goals;
}
struct StrategeticPlanCoreResponse{
    StrategeticPlanCoreResponseBased base;
    OrganizationResponseBased[] organizations;
    GoalResponseBased[] goals;
}
struct PerfomancePlanOrReportResponseBased{
    address identifier;
    string name;
    string description;
    string otherInformation;
    StrategeticPlanCoreResponseBased strategeticPlanCore;
    AdministrativeInformationResponse administrativeInformation;
    ContactInformationResponse submitter;
    ReportType reportType;
}
struct PerfomancePlanOrReportResponse{
    PerfomancePlanOrReportResponseBased base;
    StrategeticPlanCoreResponse strategeticPlanCore;
}
abstract contract OwnableOrSiblings is Ownable{
    address public registry;
    address[] public siblings;
    constructor(address _registry) Ownable(msg.sender){
        registry = _registry;
    }
    error AuthorizationError();
    modifier onlyOwnerOrSibling(){
        if(!isSibling(msg.sender))
            revert AuthorizationError();
        _;
    }
    function isSibling(address sibling) public view returns(bool){
        if(registry == sibling)
            return true;
        if(sibling == owner())
            return true;
        for(uint i = 0; i < siblings.length; i++){
            if(siblings[i] == sibling){
                return true;
            }
        }
        return false;
    }
    function addSibling(address sibling) public onlyOwner{
        for(uint i = 0; i < siblings.length; i++){
            if(siblings[i] == sibling){
                return;
            }
        }
        siblings.push(sibling);
    }
}
contract StratMLRegistry{
    using BokkyPooBahsDateTimeLibrary for uint;
    address[] roles;
    mapping(bytes => address[]) roleMap;
    address[] stakeholders;
    mapping(bytes => address[]) stakeholderMap;
    address[] organizations;
    mapping(bytes => address[]) organizationMap;
    address[] perfomancePlanOrReports;
    mapping(bytes => address[]) perfomancePlanOrReportMap;
    mapping(uint => address[]) perfomancePlanOrReportByStartDate;
    mapping(address => uint) perfomancePlanOrReportEndDate;
    mapping(uint => address[]) perfomancePlanOrReportByPublicationDate;
    event RoleAdded(address indexed roleAddress);
    event StakeholderAdded(address indexed stakeholderAddress);
    event OrganizationAdded(address indexed organizationAddress);
    event PerfomancePlanOrReportAdded(address indexed perfomancePlanOrReportAddress);
    function addRole(address role) public{
        for(uint i = 0; i < roles.length; i++){
            if(roles[i] == role){
                return;
            }
        }
        roles.push(role);
        Role roleInstance = Role(role);
        roleMap[abi.encodePacked(roleInstance.name())].push(role);
        emit RoleAdded(role);
    }
    function removeRole(address role) public{
       // Remove from roleMap
        Role roleInstance = Role(role);
        require(roleInstance.isSibling(msg.sender));
       // Remove from roles array
        _removeAddressFromArray(roles, role);

        
        bytes memory roleName = abi.encodePacked(roleInstance.name());
        _removeAddressFromArray(roleMap[roleName], role);
    }
    function getAllRoles() public view returns(RoleResponse[] memory){
        RoleResponse[] memory response = new RoleResponse[](roles.length);
        for(uint i = 0; i < roles.length; i++){
            Role role = Role(roles[i]);
            response[i] = role.getRole();
        }
        return response;   
    }
    function getRolesByName(string memory name) public view returns(RoleResponse[] memory){
        bytes memory roleName = abi.encodePacked(name);
        RoleResponse[] memory response = new RoleResponse[](roleMap[roleName].length);
        for(uint i = 0; i < roleMap[roleName].length; i++){
            Role role = Role(roleMap[roleName][i]);
            response[i] = role.getRole();
        }
        return response;
    }
    function updateRoleIndexer(address role, string memory oldName) public{
        Role roleInstance = Role(role);
        require(roleInstance.isSibling(msg.sender));
        bytes memory oldRoleName = abi.encodePacked(oldName);
        bytes memory newRoleName = abi.encodePacked(roleInstance.name());
        if(keccak256(oldRoleName) != keccak256(newRoleName)){
            _removeAddressFromArray(roleMap[oldRoleName], role);
            roleMap[newRoleName].push(role);
        }
    }
    function addStakeholder(address stakeholder) public{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == stakeholder){
                return;
            }
        }
        stakeholders.push(stakeholder);
        Stakeholder stakeholderInstance = Stakeholder(stakeholder);
        stakeholderMap[abi.encodePacked(stakeholderInstance.name())].push(stakeholder);
        emit StakeholderAdded(stakeholder);
    }
    function removeStakeholder(address stakeholder) public{
        Stakeholder stakeholderInstance = Stakeholder(stakeholder);
        require(stakeholderInstance.isSibling(msg.sender));
        // Remove from stakeholders array
        _removeAddressFromArray(stakeholders, stakeholder);

        // Remove from stakeholderMap
        
        bytes memory stakeholderName = abi.encodePacked(stakeholderInstance.name());
        _removeAddressFromArray(stakeholderMap[stakeholderName], stakeholder);
    }
    function getAllStakeholders() public view returns(StakeholderResponse[] memory){
        StakeholderResponse[] memory response = new StakeholderResponse[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response[i] = stakeholder.getStakeholder();
        }
        return response;   
    }
    function getStakeholdersByName(string memory name) public view returns(StakeholderResponse[] memory){
        bytes memory stakeholderName = abi.encodePacked(name);
        StakeholderResponse[] memory response = new StakeholderResponse[](stakeholderMap[stakeholderName].length);
        for(uint i = 0; i < stakeholderMap[stakeholderName].length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholderMap[stakeholderName][i]);
            response[i] = stakeholder.getStakeholder();
        }
        return response;
    }
    function updateStakeholderIndexer(address stakeholder, string memory oldName) public{
        Stakeholder stakeholderInstance = Stakeholder(stakeholder);
        require(stakeholderInstance.isSibling(msg.sender));
        bytes memory oldStakeholderName = abi.encodePacked(oldName);
        bytes memory newStakeholderName = abi.encodePacked(stakeholderInstance.name());
        if(keccak256(oldStakeholderName) != keccak256(newStakeholderName)){
            _removeAddressFromArray(stakeholderMap[oldStakeholderName], stakeholder);
            stakeholderMap[newStakeholderName].push(stakeholder);
        }
    }
    function addOrganization(address organization) public{
        for(uint i = 0; i < organizations.length; i++){
            if(organizations[i] == organization){
                return;
            }
        }
        organizations.push(organization);
        Organization organizationInstance = Organization(organization);
        organizationMap[abi.encodePacked(organizationInstance.name())].push(organization);
        emit OrganizationAdded(organization);
    }
    function removeOrganization(address organization) public{
        Organization organizationInstance = Organization(organization);
        require(organizationInstance.isSibling(msg.sender));
        // Remove from organizations array
        _removeAddressFromArray(organizations, organization);

        // Remove from organizationMap
        
        bytes memory organizationName = abi.encodePacked(organizationInstance.name());
        _removeAddressFromArray(organizationMap[organizationName], organization);
    }
    function getAllOrganizations() public view returns(OrganizationResponse[] memory){
        OrganizationResponse[] memory response = new OrganizationResponse[](organizations.length);
        for(uint i = 0; i < organizations.length; i++){
            Organization organization = Organization(organizations[i]);
            response[i] = organization.getOrganizationResponse();
        }
        return response;   
    }
    function getOrganizationsByName(string memory name) public view returns(OrganizationResponse[] memory){
        bytes memory organizationName = abi.encodePacked(name);
        OrganizationResponse[] memory response = new OrganizationResponse[](organizationMap[organizationName].length);
        for(uint i = 0; i < organizationMap[organizationName].length; i++){
            Organization organization = Organization(organizationMap[organizationName][i]);
            response[i] = organization.getOrganizationResponse();
        }
        return response;
    }
    function updateOrganizationIndexer(address organization, string memory oldName) public{
        Organization organizationInstance = Organization(organization);
        require(organizationInstance.isSibling(msg.sender));
        bytes memory oldOrganizationName = abi.encodePacked(oldName);
        bytes memory newOrganizationName = abi.encodePacked(organizationInstance.name());
        if(keccak256(oldOrganizationName) != keccak256(newOrganizationName)){
            _removeAddressFromArray(organizationMap[oldOrganizationName], organization);
            organizationMap[newOrganizationName].push(organization);
        }
    }
    function boxDateTime(uint time) public pure returns (uint){
        (uint year, uint month, uint day) = time.timestampToDate();
        return BokkyPooBahsDateTimeLibrary.timestampFromDate(year, month, day);
    }
    function addPerfomancePlanOrReport(address perfomancePlanOrReport) public{
        for(uint i = 0; i < perfomancePlanOrReports.length; i++){
            if(perfomancePlanOrReports[i] == perfomancePlanOrReport){
                return;
            }
        }
        perfomancePlanOrReports.push(perfomancePlanOrReport);
        PerfomancePlanOrReport perfomancePlanOrReportInstance = PerfomancePlanOrReport(perfomancePlanOrReport);
        perfomancePlanOrReportMap[abi.encodePacked(perfomancePlanOrReportInstance.name())].push(perfomancePlanOrReport);
        AdministrativeInformationResponse memory administrativeInformation = perfomancePlanOrReportInstance.getAdministrativeInformation();
        if(administrativeInformation.startDate != 0)
            perfomancePlanOrReportByStartDate[boxDateTime(administrativeInformation.startDate)].push(perfomancePlanOrReport);
        if(administrativeInformation.endDate != 0)
            perfomancePlanOrReportEndDate[perfomancePlanOrReport] = boxDateTime(administrativeInformation.endDate);
        if(administrativeInformation.publicationDate != 0)
            perfomancePlanOrReportByPublicationDate[boxDateTime(administrativeInformation.publicationDate)].push(perfomancePlanOrReport);
        emit PerfomancePlanOrReportAdded(perfomancePlanOrReport);
    }
    function removePerfomancePlanOrReport(address perfomancePlanOrReport) public{
        PerfomancePlanOrReport perfomancePlanOrReportInstance = PerfomancePlanOrReport(perfomancePlanOrReport);
        require(perfomancePlanOrReportInstance.owner() == msg.sender);
        // Remove from perfomancePlanOrReports array
        _removeAddressFromArray(perfomancePlanOrReports, perfomancePlanOrReport);

        // Remove from perfomancePlanOrReportMap
        AdministrativeInformationResponse memory administrativeInformation = perfomancePlanOrReportInstance.getAdministrativeInformation();
        bytes memory perfomancePlanOrReportName = abi.encodePacked(perfomancePlanOrReportInstance.name());
        _removeAddressFromArray(perfomancePlanOrReportMap[perfomancePlanOrReportName], perfomancePlanOrReport);
        if(administrativeInformation.startDate != 0)
            _removeAddressFromArray(perfomancePlanOrReportByStartDate[boxDateTime(administrativeInformation.startDate)], perfomancePlanOrReport);
        delete perfomancePlanOrReportEndDate[perfomancePlanOrReport];
        if(administrativeInformation.publicationDate != 0)
            _removeAddressFromArray(perfomancePlanOrReportByPublicationDate[boxDateTime(administrativeInformation.publicationDate)], perfomancePlanOrReport);
    }
    function getAllPerfomancePlanOrReports() public view returns(PerfomancePlanOrReportResponse[] memory){
        PerfomancePlanOrReportResponse[] memory response = new PerfomancePlanOrReportResponse[](perfomancePlanOrReports.length);
        for(uint i = 0; i < perfomancePlanOrReports.length; i++){
            PerfomancePlanOrReport perfomancePlanOrReport = PerfomancePlanOrReport(perfomancePlanOrReports[i]);
            response[i] = perfomancePlanOrReport.getPerfomancePlanOrReportResponse();
        }
        return response;   
    }
    function getPerfomancePlanOrReportsByName(string memory name) public view returns(PerfomancePlanOrReportResponse[] memory){
        bytes memory perfomancePlanOrReportName = abi.encodePacked(name);
        PerfomancePlanOrReportResponse[] memory response = new PerfomancePlanOrReportResponse[](perfomancePlanOrReportMap[perfomancePlanOrReportName].length);
        for(uint i = 0; i < perfomancePlanOrReportMap[perfomancePlanOrReportName].length; i++){
            PerfomancePlanOrReport perfomancePlanOrReport = PerfomancePlanOrReport(perfomancePlanOrReportMap[perfomancePlanOrReportName][i]);
            response[i] = perfomancePlanOrReport.getPerfomancePlanOrReportResponse();
        }
        return response;
    }
    function updatePerfomancePlanOrReportIndexer(address perfomancePlanOrReport, string memory oldName, uint oldStartDate, uint oldEndDate, uint oldPublicationDate) public{
        PerfomancePlanOrReport perfomancePlanOrReportInstance = PerfomancePlanOrReport(perfomancePlanOrReport);
        require(perfomancePlanOrReportInstance.owner() == msg.sender);
        bytes memory oldPerfomancePlanOrReportName = abi.encodePacked(oldName);
        bytes memory newPerfomancePlanOrReportName = abi.encodePacked(perfomancePlanOrReportInstance.name());
        if(keccak256(oldPerfomancePlanOrReportName) != keccak256(newPerfomancePlanOrReportName)){
            _removeAddressFromArray(perfomancePlanOrReportMap[oldPerfomancePlanOrReportName], perfomancePlanOrReport);
            perfomancePlanOrReportMap[newPerfomancePlanOrReportName].push(perfomancePlanOrReport);
        }
        AdministrativeInformationResponse memory administrativeInformation = perfomancePlanOrReportInstance.getAdministrativeInformation();
        if(oldStartDate != administrativeInformation.startDate){
            _removeAddressFromArray(perfomancePlanOrReportByStartDate[boxDateTime(oldStartDate)], perfomancePlanOrReport);
            if(administrativeInformation.startDate != 0)
                perfomancePlanOrReportByStartDate[boxDateTime(administrativeInformation.startDate)].push(perfomancePlanOrReport);
        }
        if(oldEndDate != administrativeInformation.endDate){
            delete perfomancePlanOrReportEndDate[perfomancePlanOrReport];
            if(administrativeInformation.endDate != 0)
                perfomancePlanOrReportEndDate[perfomancePlanOrReport] = boxDateTime(administrativeInformation.endDate);
        }
        if(oldPublicationDate != administrativeInformation.publicationDate){
            _removeAddressFromArray(perfomancePlanOrReportByPublicationDate[boxDateTime(oldPublicationDate)], perfomancePlanOrReport);
            if(administrativeInformation.publicationDate != 0)
                perfomancePlanOrReportByPublicationDate[boxDateTime(administrativeInformation.publicationDate)].push(perfomancePlanOrReport);
        }
    }
    function getAllPerfomancePlanOrReportsByValidDateRange(uint startDate, uint endDate) public view returns(PerfomancePlanOrReportResponse[] memory){
        uint start = boxDateTime(startDate);
        uint end = boxDateTime(endDate);
        uint count = 0;
        for(uint i = start; i <= end; i = i.addDays(1)){
            for(uint j = 0; j < perfomancePlanOrReportByStartDate[i].length; j++){
                if(perfomancePlanOrReportEndDate[perfomancePlanOrReportByStartDate[i][j]] <= end)
                    continue;
                count++;
            }
        }
        PerfomancePlanOrReportResponse[] memory response = new PerfomancePlanOrReportResponse[](count);
        count = 0;
        for(uint i = start; i <= end; i = i.addDays(1)){
            for(uint j = 0; j < perfomancePlanOrReportByStartDate[i].length; j++){
                if(perfomancePlanOrReportEndDate[perfomancePlanOrReportByStartDate[i][j]] <= end)
                    continue;
                response[count++] = PerfomancePlanOrReport(perfomancePlanOrReportByStartDate[i][j]).getPerfomancePlanOrReportResponse();
            }
        }
        return response;
    }
    function getAllPerformancePlanOrReportsByPublicationDateRange(uint startDate, uint endDate) public view returns(PerfomancePlanOrReportResponse[] memory){
        uint start = boxDateTime(startDate);
        uint end = boxDateTime(endDate);
        uint count = 0;
        for(uint i = start; i <= end; i = i.addDays(1)){
            for(uint j = 0; j < perfomancePlanOrReportByPublicationDate[i].length; j++){
                count++;
            }
        }
        PerfomancePlanOrReportResponse[] memory response = new PerfomancePlanOrReportResponse[](count);
        count = 0;
        for(uint i = start; i <= end; i = i.addDays(1)){
            for(uint j = 0; j < perfomancePlanOrReportByPublicationDate[i].length; j++){
                response[count++] = PerfomancePlanOrReport(perfomancePlanOrReportByPublicationDate[i][j]).getPerfomancePlanOrReportResponse();
            }
        }
        return response;
    }
    function _removeAddressFromArray(address[] storage array, address toRemove) private {
        uint length = array.length;
        for (uint i = 0; i < length; i++) {
            if (array[i] == toRemove) {
                array[i] = array[length - 1];
                array.pop();
                break;
            }
        }
    }

}
contract Role is OwnableOrSiblings {
    string public name;
    string public description;
    RoleType[] roleTypes;
    address[] stakeholders;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(address _registry, string memory _name, string memory _description, RoleType[] memory _roleTypes) OwnableOrSiblings(_registry) {
        name = _name;
        description = _description;
        for(uint i = 0; i < _roleTypes.length; i++){
            roleTypes.push(_roleTypes[i]);
        }
        StratMLRegistry(_registry).addRole(address(this));
    }
    function updateRole(string memory _name, string memory _description, RoleType[] memory _roleTypes) public onlyOwnerOrSibling{
        bool nameChanged = keccak256(abi.encodePacked(name)) != keccak256(abi.encodePacked(_name));
        string memory oldName = name;
        name = _name;
        description = _description;
        for(uint i = 0; i < roleTypes.length; i++){
            roleTypes.pop();
        }
        for(uint i = 0; i < _roleTypes.length; i++){
            roleTypes.push(_roleTypes[i]);
        }
        if(nameChanged){
            StratMLRegistry(registry).updateRoleIndexer(address(this), oldName);
        }
    }
    function addStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                return;
            }
        }
        stakeholders.push(_stakeholderAddress);
        emit StakeholderAdded(_stakeholderAddress);
    }
    function removeStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                stakeholders[i] = stakeholders[stakeholders.length - 1];
                stakeholders.pop();
                break;
            }
        }
    }
    function getRoleTypes() public view returns(RoleType[] memory){
        return roleTypes;
    }
    function getRoleBase() public view returns(RoleResponseBased memory){
        RoleResponseBased memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.roleTypes = roleTypes;
        response.stakeholders = stakeholders;
        return response;
    }
    function getRole() public view returns(RoleResponse memory){
        RoleResponse memory response;
        response.base = getRoleBase();
        response.stakeholders = new StakeholderResponseBased[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholderBase();
        }
        return response;
    }
    function getStakeholderAddresses() public view returns(address[] memory){
        return stakeholders;
    }
}
contract Stakeholder is OwnableOrSiblings {
    string public name;
    StakeholderType public stakeholderType;
    address[] public roles;
    string public description; 

    constructor(address _registry, string memory _name, StakeholderType _stakeholderType, address[] memory _roles, string memory _description) OwnableOrSiblings(_registry)  {
        name = _name;
        stakeholderType = _stakeholderType;
        roles = _roles;
        description = _description;
    }

    function updateStakeholder(string memory _name, StakeholderType _stakeholderType, address[] memory _newRoles, string memory _description) public onlyOwnerOrSibling {
        name = _name;
        stakeholderType = _stakeholderType;
        description = _description;
        // Remove from old roles
        for(uint i = 0; i < roles.length; i++) {
            Role role = Role(roles[i]);
            role.removeStakeholder(address(this));
        }

        // Add to new roles
        for(uint i = 0; i < _newRoles.length; i++) {
            Role role = Role(_newRoles[i]);
            role.addStakeholder(address(this));
        }

        roles = _newRoles;
    }
    function getStakeholderBase() public view returns(StakeholderResponseBased memory){
        StakeholderResponseBased memory response;
        response.identifier = address(this);
        response.name = name;
        response.stakeholderType = stakeholderType;
        response.roles = roles;
        return response;
    }
    function getStakeholder() public view returns(StakeholderResponse memory){
        StakeholderResponse memory response;
        response.base = getStakeholderBase(); 
        response.description = description;
        response.roles = new RoleResponseBased[](roles.length);
        for(uint i = 0; i < roles.length; i++){
            Role role = Role(roles[i]);
            response.roles[i] = role.getRoleBase();
        }
        return response;
    }
    function getRoles() public view returns(address[] memory){
        return roles;
    }
}
contract Relationship is OwnableOrSiblings {
    string public name;
    string public description;
    RelationshipType public relationshipType;
    Reference[] references;
    event ReferenceAdded(EntityTypes entityType, address indexed identifier);
    constructor(address _registry, string memory _name, string memory _description, RelationshipType _relationshipType) OwnableOrSiblings(_registry){
        name = _name;
        description = _description;
        relationshipType = _relationshipType;
    }
    function updateRelationship(string memory _name, string memory _description, RelationshipType _relationshipType) public onlyOwnerOrSibling{
        name = _name;
        description = _description;
        relationshipType = _relationshipType;
    }
    function addReference(EntityTypes _entityType, address _identifier) public onlyOwnerOrSibling{
        for(uint i = 0; i < references.length; i++){
            if(references[i].identifier == _identifier){
                return;
            }
        }
        references.push(Reference(_entityType, _identifier));
        emit ReferenceAdded(_entityType, _identifier);
    }
    function removeReference(address _identifier) public onlyOwnerOrSibling{
        for(uint i = 0; i < references.length; i++){
            if(references[i].identifier == _identifier){
                references[i] = references[references.length - 1];
                references.pop();
                break;
            }
        }
    }
    function getReferences() public view returns(Reference[] memory){
        return references;
    }
    function getRelationship() public view returns(RelationshipResponse memory){
        RelationshipResponse memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.relationshipType = relationshipType;
        response.references = references;
        return response;
    }
}
contract PerformanceIndicator is OwnableOrSiblings{
    string public sequenceIndicator;
    string public measurementDimension;
    string public unitOfMeasurement;
    address[] relationships;
    MeasurementInstance[] measurementInstances;
    string public otherInformation;
    ValueChainStageType public vauleChangeStage;
    PerfomanceIndicatorType public perfomanceIndicator;
    constructor(address _registry, string memory _sequenceIndicator, string memory _measurementDimension, 
        string memory _unitOfMeasurement, PerfomanceIndicatorType _perfomanceIndicator, string memory _otherInformation,
        ValueChainStageType _vauleChangeStage) OwnableOrSiblings(_registry){
        sequenceIndicator = _sequenceIndicator;
        measurementDimension = _measurementDimension;
        unitOfMeasurement = _unitOfMeasurement;
        perfomanceIndicator = _perfomanceIndicator;
        otherInformation = _otherInformation;
        vauleChangeStage = _vauleChangeStage;
    }
    function addRelationship(address _relationshipAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < relationships.length; i++){
            if(relationships[i] == _relationshipAddress){
                return;
            }
        }
        relationships.push(_relationshipAddress);
    }
    function getRelationships() public view returns(address[] memory){
        return relationships;
    }
    function removeRelationship(address _relationshipAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < relationships.length; i++){
            if(relationships[i] == _relationshipAddress){
                relationships[i] = relationships[relationships.length - 1];
                relationships.pop();
                break;
            }
        }
    }
    function addMeasurementInstance(MeasurementInstance memory _measurementInstance) public onlyOwnerOrSibling{
        measurementInstances.push();
        for(uint i = 0; i < _measurementInstance.actualResults.length; i++){
            measurementInstances[measurementInstances.length - 1].actualResults.push();
            measurementInstances[measurementInstances.length - 1].actualResults[i].startDate = _measurementInstance.actualResults[i].startDate;
            measurementInstances[measurementInstances.length - 1].actualResults[i].endDate = _measurementInstance.actualResults[i].endDate;
            measurementInstances[measurementInstances.length - 1].actualResults[i].numberOfUnits = _measurementInstance.actualResults[i].numberOfUnits;
            measurementInstances[measurementInstances.length - 1].actualResults[i].descriptor.name = _measurementInstance.actualResults[i].descriptor.name;
            measurementInstances[measurementInstances.length - 1].actualResults[i].descriptor.value = _measurementInstance.actualResults[i].descriptor.value;
            measurementInstances[measurementInstances.length - 1].actualResults[i].description = _measurementInstance.actualResults[i].description;
        }
        for(uint i = 0; i < _measurementInstance.targetResults.length; i++){
            measurementInstances[measurementInstances.length - 1].actualResults.push();
            measurementInstances[measurementInstances.length - 1].targetResults[i].startDate = _measurementInstance.targetResults[i].startDate;
            measurementInstances[measurementInstances.length - 1].targetResults[i].endDate = _measurementInstance.targetResults[i].endDate;
            measurementInstances[measurementInstances.length - 1].targetResults[i].numberOfUnits = _measurementInstance.targetResults[i].numberOfUnits;
            measurementInstances[measurementInstances.length - 1].targetResults[i].descriptor.name = _measurementInstance.targetResults[i].descriptor.name;
            measurementInstances[measurementInstances.length - 1].targetResults[i].descriptor.value = _measurementInstance.targetResults[i].descriptor.value;
            measurementInstances[measurementInstances.length - 1].targetResults[i].description = _measurementInstance.targetResults[i].description;
        }
    }
    function removeMeasurementInstance(uint index) public onlyOwnerOrSibling{
       require(index < measurementInstances.length);

        // Swap the element at index with the last element if index is not the last element
        if (index < measurementInstances.length - 1) {
            MeasurementInstance memory lastElement = measurementInstances[measurementInstances.length - 1];
            for(uint i = 0; i < measurementInstances[index].actualResults.length; i++){
                measurementInstances[index].actualResults.pop();
            }
            for(uint i = 0; i < measurementInstances[index].targetResults.length; i++){
                measurementInstances[index].targetResults.pop();
            }
            for(uint i = 0; i < lastElement.actualResults.length; i++){
                measurementInstances[index].actualResults.push();
                measurementInstances[index].actualResults[i].startDate = measurementInstances[measurementInstances.length - 1].actualResults[i].startDate;
                measurementInstances[index].actualResults[i].endDate = measurementInstances[measurementInstances.length - 1].actualResults[i].endDate;
                measurementInstances[index].actualResults[i].numberOfUnits = measurementInstances[measurementInstances.length - 1].actualResults[i].numberOfUnits;
                measurementInstances[index].actualResults[i].descriptor.name = measurementInstances[measurementInstances.length - 1].actualResults[i].descriptor.name;
                measurementInstances[index].actualResults[i].descriptor.value = measurementInstances[measurementInstances.length - 1].actualResults[i].descriptor.value;
                measurementInstances[index].actualResults[i].description = measurementInstances[measurementInstances.length - 1].actualResults[i].description;
            }
            for(uint i = 0; i < lastElement.targetResults.length; i++){
                measurementInstances[index].targetResults.push();
                measurementInstances[index].targetResults[i].startDate = measurementInstances[measurementInstances.length - 1].targetResults[i].startDate;
                measurementInstances[index].targetResults[i].endDate = measurementInstances[measurementInstances.length - 1].targetResults[i].endDate;
                measurementInstances[index].targetResults[i].numberOfUnits = measurementInstances[measurementInstances.length - 1].targetResults[i].numberOfUnits;
                measurementInstances[index].targetResults[i].descriptor.name = measurementInstances[measurementInstances.length - 1].targetResults[i].descriptor.name;
                measurementInstances[index].targetResults[i].descriptor.value = measurementInstances[measurementInstances.length - 1].targetResults[i].descriptor.value;
                measurementInstances[index].targetResults[i].description = measurementInstances[measurementInstances.length - 1].targetResults[i].description;
            }
        }
        // Remove the last element
        measurementInstances.pop();
    }
    function getMeasurementInstances() public view returns(MeasurementInstance[] memory){
        return measurementInstances;
    }
    function getPerformanceIndicator() public view returns(PermformanceIndicatorResponse memory){
        PermformanceIndicatorResponse memory response;
        response.identifier = address(this);
        response.seqeunceIndicator = sequenceIndicator;
        response.measurementDimension = measurementDimension;
        response.unitOfMeasurement = unitOfMeasurement;
        response.relationships = new RelationshipResponse[](relationships.length);
        for(uint i = 0; i < relationships.length; i++){
            Relationship relationship = Relationship(relationships[i]);
            response.relationships[i] = relationship.getRelationship();
        }
        response.measurementInstances = new MeasurementInstance[](measurementInstances.length);
        for(uint i = 0; i < measurementInstances.length; i++){
            response.measurementInstances[i].actualResults = new ActualResult[](measurementInstances[i].actualResults.length);
            for(uint j = 0; j < measurementInstances[i].actualResults.length; j++){
                
                response.measurementInstances[i].actualResults[j].startDate = measurementInstances[i].actualResults[j].startDate;
                response.measurementInstances[i].actualResults[j].endDate = measurementInstances[i].actualResults[j].endDate;
                response.measurementInstances[i].actualResults[j].numberOfUnits = measurementInstances[i].actualResults[j].numberOfUnits;
                response.measurementInstances[i].actualResults[j].descriptor.name = measurementInstances[i].actualResults[j].descriptor.name;
                response.measurementInstances[i].actualResults[j].descriptor.value = measurementInstances[i].actualResults[j].descriptor.value;
                response.measurementInstances[i].actualResults[j].description = measurementInstances[i].actualResults[j].description;
            }
            response.measurementInstances[i].targetResults = new TargetResult[](measurementInstances[i].targetResults.length);
            for(uint j = 0; j < measurementInstances[i].targetResults.length; j++){
                response.measurementInstances[i].targetResults[j].startDate = measurementInstances[i].targetResults[j].startDate;
                response.measurementInstances[i].targetResults[j].endDate = measurementInstances[i].targetResults[j].endDate;
                response.measurementInstances[i].targetResults[j].numberOfUnits = measurementInstances[i].targetResults[j].numberOfUnits;
                response.measurementInstances[i].targetResults[j].descriptor.name = measurementInstances[i].targetResults[j].descriptor.name;
                response.measurementInstances[i].targetResults[j].descriptor.value = measurementInstances[i].targetResults[j].descriptor.value;
                response.measurementInstances[i].targetResults[j].description = measurementInstances[i].targetResults[j].description;
            }
        }
        response.otherInformation = otherInformation;
        response.vauleChangeStage = vauleChangeStage;
        response.perfomanceIndicator = perfomanceIndicator;
        return response;
    }
    function updatePerformanceIndicator(string memory _sequenceIndicator, string memory _measurementDimension, string memory _unitOfMeasurement, PerfomanceIndicatorType _perfomanceIndicator) public onlyOwnerOrSibling{
        sequenceIndicator = _sequenceIndicator;
        measurementDimension = _measurementDimension;
        unitOfMeasurement = _unitOfMeasurement;
        perfomanceIndicator = _perfomanceIndicator;
    }
}
contract Objective is OwnableOrSiblings{
    string public name;
    string public description;
    string public sequenceIndicator;
    address[] stakeholders;
    string public otherInformation;
    address[] perfomanceIndicators;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(address _registry, string memory _name, string memory _description, string memory _sequenceIndicator, string memory _otherInformation) OwnableOrSiblings(_registry){
        name = _name;
        description = _description;
        sequenceIndicator = _sequenceIndicator;
        otherInformation = _otherInformation;
    }
    function addStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                return;
            }
        }
        stakeholders.push(_stakeholderAddress);
        emit StakeholderAdded(_stakeholderAddress);
    }
    function removeStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                stakeholders[i] = stakeholders[stakeholders.length - 1];
                stakeholders.pop();
                break;
            }
        }
    }
    function getStakeholders() public view returns(address[] memory){
        return stakeholders;
    }
    function addPerformanceIndicator(address _performanceIndicatorAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < perfomanceIndicators.length; i++){
            if(perfomanceIndicators[i] == _performanceIndicatorAddress){
                return;
            }
        }
        perfomanceIndicators.push(_performanceIndicatorAddress);
    }
    function removePerformanceIndicator(address _performanceIndicatorAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < perfomanceIndicators.length; i++){
            if(perfomanceIndicators[i] == _performanceIndicatorAddress){
                perfomanceIndicators[i] = perfomanceIndicators[perfomanceIndicators.length - 1];
                perfomanceIndicators.pop();
                break;
            }
        }
    }
    function getPerformanceIndicators() public view returns(address[] memory){
        return perfomanceIndicators;
    }
    function getObjectiveResponseBased() public view returns(ObjectiveResponseBased memory){
        ObjectiveResponseBased memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.sequenceIndicator = sequenceIndicator;
        response.stakeholders = stakeholders;
        response.otherInformation = otherInformation;
        response.perfomanceIndicators = new PermformanceIndicatorResponse[](perfomanceIndicators.length);
        for(uint i = 0; i < perfomanceIndicators.length; i++){
            PerformanceIndicator performanceIndicator = PerformanceIndicator(perfomanceIndicators[i]);
            response.perfomanceIndicators[i] = performanceIndicator.getPerformanceIndicator();
        }
        return response;
    }
    function getObjectiveResponse() public view returns(ObjectiveResponse memory){
        ObjectiveResponse memory response;
        response.base = getObjectiveResponseBased();
        response.stakeholders = new StakeholderResponseBased[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholderBase();
        }
        return response;
    }
}
contract Goal is OwnableOrSiblings{
    string public name;
    string public description;
    string public sequenceIndicator;
    address[] stakeholders;
    string public otherInformation;
    address[] objectives;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(address _registry, string memory _name, string memory _description, string memory _sequenceIndicator, string memory _otherInformation) OwnableOrSiblings(_registry){
        name = _name;
        description = _description;
        sequenceIndicator = _sequenceIndicator;
        otherInformation = _otherInformation;
    }
    function addStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                return;
            }
        }
        stakeholders.push(_stakeholderAddress);
        emit StakeholderAdded(_stakeholderAddress);
    }
    function removeStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                stakeholders[i] = stakeholders[stakeholders.length - 1];
                stakeholders.pop();
                break;
            }
        }
    }
    function addObjective(address _objectiveAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < objectives.length; i++){
            if(objectives[i] == _objectiveAddress){
                return;
            }
        }
        objectives.push(_objectiveAddress);
    }
    function removeObjective(address _objectiveAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < objectives.length; i++){
            if(objectives[i] == _objectiveAddress){
                objectives[i] = objectives[objectives.length - 1];
                objectives.pop();
                break;
            }
        }
    }
    function getGoalResponseBased() public view returns(GoalResponseBased memory){
        GoalResponseBased memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.sequenceIndicator = sequenceIndicator;
        response.stakeholders = stakeholders;
        response.otherInformation = otherInformation;
        response.objectives = objectives;
        return response;
    }
    function getGoalResponse() public view returns(GoalResponse memory){
        GoalResponse memory response;
        response.base = getGoalResponseBased();
        response.stakeholders = new StakeholderResponseBased[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholderBase();
        }
        response.objectives = new ObjectiveResponseBased[](objectives.length);
        for(uint i = 0; i < objectives.length; i++){
            Objective objective = Objective(objectives[i]);
            response.objectives[i] = objective.getObjectiveResponseBased();
        }
        return response;
    }
}
contract Organization is OwnableOrSiblings{
    string public name;
    string public description;
    string public acryonym;
    address[] stakeholders;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(address _registry, string memory _name, string memory _description, string memory _acryonym) OwnableOrSiblings(_registry){
        name = _name;
        description = _description;
        acryonym = _acryonym;
    }
    function addStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                return;
            }
        }
        stakeholders.push(_stakeholderAddress);
        emit StakeholderAdded(_stakeholderAddress);
    }
    function removeStakeholder(address _stakeholderAddress) public onlyOwnerOrSibling{
        for(uint i = 0; i < stakeholders.length; i++){
            if(stakeholders[i] == _stakeholderAddress){
                stakeholders[i] = stakeholders[stakeholders.length - 1];
                stakeholders.pop();
                break;
            }
        }
    }
    function getStakeholders() public view returns(address[] memory){
        return stakeholders;
    }
    function getOrganizationResponseBased() public view returns(OrganizationResponseBased memory){
        OrganizationResponseBased memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.acryonym = acryonym;
        response.stakeholders = new StakeholderResponseBased[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i].identifier = stakeholders[i];
            response.stakeholders[i].name = stakeholder.name();
            response.stakeholders[i].stakeholderType = stakeholder.stakeholderType();
            response.stakeholders[i].roles = stakeholder.getRoles();
        }
        return response;
    }
    function getOrganizationResponse() public view returns(OrganizationResponse memory){
        OrganizationResponse memory response;
        response.base = getOrganizationResponseBased();
        response.stakeholders = new StakeholderResponse[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholder();
        }
        return response;
    }
}
contract Mission is OwnableOrSiblings{
    string public description;
    constructor(address _registry, string memory _description) OwnableOrSiblings(_registry){
        description = _description;
    }
    function updateMission(string memory _description) public onlyOwnerOrSibling{
        description = _description;
    }
    function getMissionResponse() public view returns(MissionResponse memory){
        MissionResponse memory response;
        response.identifier = address(this);
        response.description = description;
        return response;
    }
}
contract Vision is OwnableOrSiblings{
    string public description;
    constructor(address _registry, string memory _description) OwnableOrSiblings(_registry){
        description = _description;
    }
    function updateVision(string memory _description) public onlyOwnerOrSibling{
        description = _description;
    }
    function getVisionResponse() public view returns(VisionResponse memory){
        VisionResponse memory response;
        response.identifier = address(this);
        response.description = description;
        return response;
    }
}
contract AdministrativeInformation is OwnableOrSiblings{
    uint public startDate;
    uint public endDate;
    uint public publicationDate;
    string public source;
    constructor(address _registry, uint _startDate, uint _endDate, uint _publicationDate, string memory _source) OwnableOrSiblings(_registry){
        startDate = _startDate;
        endDate = _endDate;
        publicationDate = _publicationDate;
        source = _source;
    }
    function updateAdministrativeInformation(uint _startDate, uint _endDate, uint _publicationDate, string memory _source) public onlyOwnerOrSibling{
        startDate = _startDate;
        endDate = _endDate;
        publicationDate = _publicationDate;
        source = _source;
    }
    function getAdministrativeInformationResponse() public view returns(AdministrativeInformationResponse memory){
        AdministrativeInformationResponse memory response;
        response.identifier = address(this);
        response.startDate = startDate;
        response.endDate = endDate;
        response.publicationDate = publicationDate;
        response.source = source;
        return response;
    }
}
contract ContactInformation is OwnableOrSiblings{
    string public givenName;
    string public surname;
    string public phoneNumber;
    string public emailAddress;
    constructor(address _registry, string memory _givenName, string memory _surname, string memory _phoneNumber, string memory _emailAddress) OwnableOrSiblings(_registry){
        givenName = _givenName;
        surname = _surname;
        phoneNumber = _phoneNumber;
        emailAddress = _emailAddress;
    }
    function updateContactInformation(string memory _givenName, string memory _surname, string memory _phoneNumber, string memory _emailAddress) public onlyOwnerOrSibling{
        givenName = _givenName;
        surname = _surname;
        phoneNumber = _phoneNumber;
        emailAddress = _emailAddress;
    }
    function getContactInformationResponse() public view returns(ContactInformationResponse memory){
        ContactInformationResponse memory response;
        response.identifier = address(this);
        response.givenName = givenName;
        response.surname = surname;
        response.phoneNumber = phoneNumber;
        response.emailAddress = emailAddress;
        return response;
    }
}
contract PerfomancePlanOrReport is Ownable{
    struct StrategicPlan {
        address vision;
        address mission;
        Value[] values;
        address[] goals;
    }
    address public registry;
    string public name;
    string public description;
    string public otherInformation;
    address[] organizations;
    StrategicPlan private strategeticPlan;
    address administrativeInformation;
    address submitter;
    ReportType reportType;
    constructor(address _registry, string memory _name, string memory _description, ReportType _reportType, string memory _otherInformation) Ownable(msg.sender){
        registry = _registry; 
        name = _name;
        description = _description;
        reportType = _reportType;
        otherInformation = _otherInformation;
    }
    function updateVision(address _vision) public onlyOwner{
        require(strategeticPlan.vision == address(0));
        strategeticPlan.vision = _vision;
    }
    function setMission(address _mission) public onlyOwner{
        require(strategeticPlan.mission == address(0));
        strategeticPlan.mission = _mission;
    }
    function addOrganization(address _organizationAddress) public onlyOwner{
        for(uint i = 0; i < organizations.length; i++){
            if(organizations[i] == _organizationAddress){
                return;
            }
        }
        organizations.push(_organizationAddress);
    }
    function removeOrganization(address _organizationAddress) public onlyOwner{
        for(uint i = 0; i < organizations.length; i++){
            if(organizations[i] == _organizationAddress){
                organizations[i] = organizations[organizations.length - 1];
                organizations.pop();
                break;
            }
        }
    }
    function addValue(string memory _name, string memory _description) public onlyOwner{
        strategeticPlan.values.push(Value(_name, _description));
    }
    error OutOfBounds();
    function removeValue(uint index) public onlyOwner{
        if(index >= strategeticPlan.values.length) revert OutOfBounds();

        // Swap the element at index with the last element if index is not the last element
        if (index < strategeticPlan.values.length - 1) {
            strategeticPlan.values[index] = strategeticPlan.values[strategeticPlan.values.length - 1];
        }
        // Remove the last element
        strategeticPlan.values.pop();
    }
    function updateValue(uint index, string memory _name, string memory _description) public onlyOwner{
        if(index >= strategeticPlan.values.length) revert OutOfBounds();
        strategeticPlan.values[index].name = _name;
        strategeticPlan.values[index].description = _description;
    }
    function addGoal(address _goalAddress) public onlyOwner{
        for(uint i = 0; i < strategeticPlan.goals.length; i++){
            if(strategeticPlan.goals[i] == _goalAddress){
                return;
            }
        }
        strategeticPlan.goals.push(_goalAddress);
    }
    function removeGoal(address _goalAddress) public onlyOwner{
        for(uint i = 0; i < strategeticPlan.goals.length; i++){
            if(strategeticPlan.goals[i] == _goalAddress){
                strategeticPlan.goals[i] = strategeticPlan.goals[strategeticPlan.goals.length - 1];
                strategeticPlan.goals.pop();
                break;
            }
        }
    }
    function setAdministrativeInformation(address _adminInfo) public onlyOwner{
        require(administrativeInformation == address(0));
        administrativeInformation = _adminInfo;
    }
    function setsubmitter(address _submitter) public onlyOwner{
        require(submitter == address(0));
        submitter = _submitter;
    }
    function getOrganizations() public view returns(address[] memory){
        return organizations;
    }
    function getValues() public view returns(Value[] memory){
        return strategeticPlan.values;
    }
    function getGoals() public view returns(address[] memory){
        return strategeticPlan.goals;
    }
    function getAdministrativeInformation() public view returns(AdministrativeInformationResponse memory){
        require(administrativeInformation != address(0));
        return AdministrativeInformation(administrativeInformation).getAdministrativeInformationResponse();
    }
    function getsubmitter() public view returns(ContactInformationResponse memory){
        require(submitter != address(0));
        return ContactInformation(submitter).getContactInformationResponse();
    }
    function getPerfomancePlanOrReportResponseBased() public view returns(PerfomancePlanOrReportResponseBased memory){
        PerfomancePlanOrReportResponseBased memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.otherInformation = otherInformation;
        response.strategeticPlanCore = getStrategeticPlanCoreResponseBased();
        if(administrativeInformation != address(0))
            response.administrativeInformation = AdministrativeInformation(administrativeInformation).getAdministrativeInformationResponse();
        if(submitter != address(0))
            response.submitter = ContactInformation(submitter).getContactInformationResponse();
        response.reportType = reportType;
        return response;
    }
    function getPerfomancePlanOrReportResponse() public view returns(PerfomancePlanOrReportResponse memory){
        PerfomancePlanOrReportResponse memory response;
        response.base = getPerfomancePlanOrReportResponseBased();
        response.strategeticPlanCore = getStrategeticPlanCoreResponse();
        return response;
    }
    function getStrategeticPlanCoreResponseBased() public view returns(StrategeticPlanCoreResponseBased memory){
        StrategeticPlanCoreResponseBased memory response;
        response.organizations = organizations;
        if(strategeticPlan.vision != address(0))
            response.vision = Vision(strategeticPlan.vision).getVisionResponse();
        if(strategeticPlan.mission != address(0))
            response.mission = Mission(strategeticPlan.mission).getMissionResponse();
        response.values = strategeticPlan.values;
        response.goals = strategeticPlan.goals;
        return response;
    }
    function getStrategeticPlanCoreResponse() public view returns(StrategeticPlanCoreResponse memory){
        StrategeticPlanCoreResponse memory response;
        response.base = getStrategeticPlanCoreResponseBased();
        response.organizations = new OrganizationResponseBased[](organizations.length);
        for(uint i = 0; i < organizations.length; i++){
            Organization organization = Organization(organizations[i]);
            response.organizations[i] = organization.getOrganizationResponseBased();
        }
        response.goals = new GoalResponseBased[](strategeticPlan.goals.length);
        for(uint i = 0; i < strategeticPlan.goals.length; i++){
            Goal goal = Goal(strategeticPlan.goals[i]);
            response.goals[i] = goal.getGoalResponseBased();
        }
        return response;
    }
    
}
