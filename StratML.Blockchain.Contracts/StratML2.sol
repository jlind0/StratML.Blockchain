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
struct RoleResponseBase{
    address identifier;
    string name;
    string description;
    RoleType[] roleTypes;
    address[] stakeholders;
}
struct RoleResponse{
    RoleResponseBase base;
    StakeholderResponseBase[] stakeholders;
}
struct StakeholderResponseBase{
    address identifier;
    string name;
    StakeholderType stakeholderType;
    address[] roles;
}
struct StakeholderResponse{
    StakeholderResponseBase base;
    RoleResponseBase[] roles;
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
    PerfomanceIndicator,
    Objective,
    Organization,
    Goal
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
    ValueChainStageType vauleChangeState;
    PerfomanceIndicatorType perfomanceIndicator;
}
struct ObjectiveResponseBase{
    address identifier;
    string name;
    string description;
    string sequenceIndicator;
    address[] stakeholders;
    string otherInformation;
    PermformanceIndicatorResponse[] perfomanceIndicators;
}
struct ObjectiveResponse{
    ObjectiveResponseBase base;
    StakeholderResponseBase[] stakeholders;
}
struct GoalResponseBase{
    address identifier;
    string name;
    string description;
    string sequenceIndicator;
    address[] stakeholders;
    string otherInformation;
    address[] objectives;
}
struct GoalResponse{
    GoalResponseBase base;
    StakeholderResponseBase[] stakeholders;
    ObjectiveResponseBase[] objectives;
}
struct OrganizationResponseBase{
    address identifier;
    string name;
    string description;
    string acryonym;
    StakeholderResponseBase[] stakeholders;
}
struct OrganizationResponse{
    OrganizationResponseBase base;
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
struct StrategeticPlanCoreResponseBase{
    address[] organizations;
    VisionResponse vision;
    MissionResponse mission;
    Value[] values;
    address[] goals;
}
struct StrategeticPlanCoreResponse{
    StrategeticPlanCoreResponseBase base;
    OrganizationResponseBase[] organizations;
    GoalResponseBase[] goals;
}
struct PerfomancePlanOrReportResponseBase{
    address identifier;
    string name;
    string description;
    string otherInformation;
    StrategeticPlanCoreResponseBase strategeticPlanCore;
    AdministrativeInformationResponse administrativeInformation;
    ContactInformationResponse sumbitter;
    ReportType reportType;
}
struct PerfomancePlanOrReportResponse{
    PerfomancePlanOrReportResponseBase base;
    StrategeticPlanCoreResponse strategeticPlanCore;
}
contract Role is Ownable {
    string public name;
    string public description;
    RoleType[] roleTypes;
    address[] stakeholders;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(string memory _name, string memory _description, RoleType[] memory _roleTypes) Ownable(msg.sender){
        name = _name;
        description = _description;
        for(uint i = 0; i < _roleTypes.length; i++){
            roleTypes.push(_roleTypes[i]);
        }
    }
    function updateRole(string memory _name, string memory _description, RoleType[] memory _roleTypes) public onlyOwner{
        name = _name;
        description = _description;
        for(uint i = 0; i < roleTypes.length; i++){
            roleTypes.pop();
        }
        for(uint i = 0; i < _roleTypes.length; i++){
            roleTypes.push(_roleTypes[i]);
        }
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
    function getRoleTypes() public view returns(RoleType[] memory){
        return roleTypes;
    }
    function getRoleBase() public view returns(RoleResponseBase memory){
        RoleResponseBase memory response;
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
        response.stakeholders = new StakeholderResponseBase[](stakeholders.length);
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
    function getStakeholderBase() public view returns(StakeholderResponseBase memory){
        StakeholderResponseBase memory response;
        response.identifier = address(this);
        response.name = name;
        response.stakeholderType = stakeholderType;
        response.roles = roles;
        return response;
    }
    function getStakeholder() public view returns(StakeholderResponse memory){
        StakeholderResponse memory response;
        response.base = getStakeholderBase(); 
        response.roles = new RoleResponseBase[](roles.length);
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
contract Relationship is Ownable {
    string public name;
    string public description;
    RelationshipType public relationshipType;
    Reference[] references;
    event ReferenceAdded(EntityTypes entityType, address indexed identifier);
    constructor(string memory _name, string memory _description, RelationshipType _relationshipType) Ownable(msg.sender){
        name = _name;
        description = _description;
        relationshipType = _relationshipType;
    }
    function updateRelationship(string memory _name, string memory _description, RelationshipType _relationshipType) public onlyOwner{
        name = _name;
        description = _description;
        relationshipType = _relationshipType;
    }
    function addReference(EntityTypes _entityType, address _identifier) public onlyOwner{
        for(uint i = 0; i < references.length; i++){
            if(references[i].identifier == _identifier){
                return;
            }
        }
        references.push(Reference(_entityType, _identifier));
        emit ReferenceAdded(_entityType, _identifier);
    }
    function removeReference(address _identifier) public onlyOwner{
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
contract PerformanceIndicator is Ownable{
    string public sequenceIndicator;
    string public measurementDimension;
    string public unitOfMeasurement;
    address[] relationships;
    MeasurementInstance[] measurementInstances;
    string public otherInformation;
    ValueChainStageType public vauleChangeState;
    PerfomanceIndicatorType public perfomanceIndicator;
    constructor(string memory _sequenceIndicator, string memory _measurementDimension, string memory _unitOfMeasurement, PerfomanceIndicatorType _perfomanceIndicator) Ownable(msg.sender){
        sequenceIndicator = _sequenceIndicator;
        measurementDimension = _measurementDimension;
        unitOfMeasurement = _unitOfMeasurement;
        perfomanceIndicator = _perfomanceIndicator;
    }
    function addRelationship(address _relationshipAddress) public onlyOwner{
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
    function removeRelationship(address _relationshipAddress) public onlyOwner{
        for(uint i = 0; i < relationships.length; i++){
            if(relationships[i] == _relationshipAddress){
                relationships[i] = relationships[relationships.length - 1];
                relationships.pop();
                break;
            }
        }
    }
    function addMeasurementInstance(MeasurementInstance memory _measurementInstance) public onlyOwner{
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
    function removeMeasurementInstance(uint index) public onlyOwner{
       require(index < measurementInstances.length, "Index out of bounds");

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
        response.vauleChangeState = vauleChangeState;
        response.perfomanceIndicator = perfomanceIndicator;
        return response;
    }
    function updatePerformanceIndicator(string memory _sequenceIndicator, string memory _measurementDimension, string memory _unitOfMeasurement, PerfomanceIndicatorType _perfomanceIndicator) public onlyOwner{
        sequenceIndicator = _sequenceIndicator;
        measurementDimension = _measurementDimension;
        unitOfMeasurement = _unitOfMeasurement;
        perfomanceIndicator = _perfomanceIndicator;
    }
}
contract Objective is Ownable{
    string public name;
    string public description;
    string public sequenceIndicator;
    address[] stakeholders;
    string public otherInformation;
    address[] perfomanceIndicators;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(string memory _name, string memory _description, string memory _sequenceIndicator) Ownable(msg.sender){
        name = _name;
        description = _description;
        sequenceIndicator = _sequenceIndicator;
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
    function getStakeholders() public view returns(address[] memory){
        return stakeholders;
    }
    function addPerformanceIndicator(address _performanceIndicatorAddress) public onlyOwner{
        for(uint i = 0; i < perfomanceIndicators.length; i++){
            if(perfomanceIndicators[i] == _performanceIndicatorAddress){
                return;
            }
        }
        perfomanceIndicators.push(_performanceIndicatorAddress);
    }
    function removePerformanceIndicator(address _performanceIndicatorAddress) public onlyOwner{
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
    function getObjectiveResponseBase() public view returns(ObjectiveResponseBase memory){
        ObjectiveResponseBase memory response;
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
        response.base = getObjectiveResponseBase();
        response.stakeholders = new StakeholderResponseBase[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholderBase();
        }
        return response;
    }
}
contract Goal is Ownable{
    string public name;
    string public description;
    string public sequenceIndicator;
    address[] stakeholders;
    string public otherInformation;
    address[] objectives;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(string memory _name, string memory _description, string memory _sequenceIndicator) Ownable(msg.sender){
        name = _name;
        description = _description;
        sequenceIndicator = _sequenceIndicator;
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
    function addObjective(address _objectiveAddress) public onlyOwner{
        for(uint i = 0; i < objectives.length; i++){
            if(objectives[i] == _objectiveAddress){
                return;
            }
        }
        objectives.push(_objectiveAddress);
    }
    function removeObjective(address _objectiveAddress) public onlyOwner{
        for(uint i = 0; i < objectives.length; i++){
            if(objectives[i] == _objectiveAddress){
                objectives[i] = objectives[objectives.length - 1];
                objectives.pop();
                break;
            }
        }
    }
    function getGoalResponseBase() public view returns(GoalResponseBase memory){
        GoalResponseBase memory response;
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
        response.base = getGoalResponseBase();
        response.stakeholders = new StakeholderResponseBase[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholderBase();
        }
        response.objectives = new ObjectiveResponseBase[](objectives.length);
        for(uint i = 0; i < objectives.length; i++){
            Objective objective = Objective(objectives[i]);
            response.objectives[i] = objective.getObjectiveResponseBase();
        }
        return response;
    }
}
contract Organization is Ownable{
    string public name;
    string public description;
    string public acryonym;
    address[] stakeholders;
    event StakeholderAdded(address indexed stakeholderAddress);
    constructor(string memory _name, string memory _description, string memory _acryonym) Ownable(msg.sender){
        name = _name;
        description = _description;
        acryonym = _acryonym;
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
    function getStakeholders() public view returns(address[] memory){
        return stakeholders;
    }
    function getOrganizationResponseBase() public view returns(OrganizationResponseBase memory){
        OrganizationResponseBase memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.acryonym = acryonym;
        response.stakeholders = new StakeholderResponseBase[](stakeholders.length);
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
        response.base = getOrganizationResponseBase();
        response.stakeholders = new StakeholderResponse[](stakeholders.length);
        for(uint i = 0; i < stakeholders.length; i++){
            Stakeholder stakeholder = Stakeholder(stakeholders[i]);
            response.stakeholders[i] = stakeholder.getStakeholder();
        }
        return response;
    }
}
contract Mission is Ownable{
    string public description;
    constructor(string memory _description) Ownable(msg.sender){
        description = _description;
    }
    function updateMission(string memory _description) public onlyOwner{
        description = _description;
    }
    function getMissionResponse() public view returns(MissionResponse memory){
        MissionResponse memory response;
        response.identifier = address(this);
        response.description = description;
        return response;
    }
}
contract Vision is Ownable{
    string public description;
    constructor(string memory _description) Ownable(msg.sender){
        description = _description;
    }
    function updateVision(string memory _description) public onlyOwner{
        description = _description;
    }
    function getVisionResponse() public view returns(VisionResponse memory){
        VisionResponse memory response;
        response.identifier = address(this);
        response.description = description;
        return response;
    }
}
contract AdministrativeInformation is Ownable{
    uint public startDate;
    uint public endDate;
    uint public publicationDate;
    string public source;
    constructor(uint _startDate, uint _endDate, uint _publicationDate, string memory _source) Ownable(msg.sender){
        startDate = _startDate;
        endDate = _endDate;
        publicationDate = _publicationDate;
        source = _source;
    }
    function updateAdministrativeInformation(uint _startDate, uint _endDate, uint _publicationDate, string memory _source) public onlyOwner{
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
contract ContactInformation is Ownable{
    string public givenName;
    string public surname;
    string public phoneNumber;
    string public emailAddress;
    constructor(string memory _givenName, string memory _surname, string memory _phoneNumber, string memory _emailAddress) Ownable(msg.sender){
        givenName = _givenName;
        surname = _surname;
        phoneNumber = _phoneNumber;
        emailAddress = _emailAddress;
    }
    function updateContactInformation(string memory _givenName, string memory _surname, string memory _phoneNumber, string memory _emailAddress) public onlyOwner{
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
    string public name;
    string public description;
    string public otherInformation;
    address[] organizations;
    address vision;
    address mission;
    Value[] values;
    address[] goals;
    AdministrativeInformation administrativeInformation;
    ContactInformation sumbitter;
    ReportType reportType;
    event OrganizationAdded(address indexed organizationAddress);
    constructor(string memory _name, string memory _description, ReportType _reportType) Ownable(msg.sender){
        name = _name;
        description = _description;
        reportType = _reportType;
    }
    function addOrganization(address _organizationAddress) public onlyOwner{
        for(uint i = 0; i < organizations.length; i++){
            if(organizations[i] == _organizationAddress){
                return;
            }
        }
        organizations.push(_organizationAddress);
        emit OrganizationAdded(_organizationAddress);
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
        values.push(Value(_name, _description));
    }
    function removeValue(uint index) public onlyOwner{
        require(index < values.length, "Index out of bounds");

        // Swap the element at index with the last element if index is not the last element
        if (index < values.length - 1) {
            values[index] = values[values.length - 1];
        }
        // Remove the last element
        values.pop();
    }
    function updateValue(uint index, string memory _name, string memory _description) public onlyOwner{
        require(index < values.length, "Index out of bounds");
        values[index].name = _name;
        values[index].description = _description;
    }
    function addGoal(address _goalAddress) public onlyOwner{
        for(uint i = 0; i < goals.length; i++){
            if(goals[i] == _goalAddress){
                return;
            }
        }
        goals.push(_goalAddress);
    }
    function removeGoal(address _goalAddress) public onlyOwner{
        for(uint i = 0; i < goals.length; i++){
            if(goals[i] == _goalAddress){
                goals[i] = goals[goals.length - 1];
                goals.pop();
                break;
            }
        }
    }
    function updateAdministrativeInformation(uint _startDate, uint _endDate, uint _publicationDate, string memory _source) public onlyOwner{
        administrativeInformation.updateAdministrativeInformation(_startDate, _endDate, _publicationDate, _source);
    }
    function updateSumbitter(string memory _givenName, string memory _surname, string memory _phoneNumber, string memory _emailAddress) public onlyOwner{
        sumbitter.updateContactInformation(_givenName, _surname, _phoneNumber, _emailAddress);
    }
    function getOrganizations() public view returns(address[] memory){
        return organizations;
    }
    function getValues() public view returns(Value[] memory){
        return values;
    }
    function getGoals() public view returns(address[] memory){
        return goals;
    }
    function getAdministrativeInformation() public view returns(AdministrativeInformationResponse memory){
        return administrativeInformation.getAdministrativeInformationResponse();
    }
    function getSumbitter() public view returns(ContactInformationResponse memory){
        return sumbitter.getContactInformationResponse();
    }
    function getPerfomancePlanOrReportResponseBase() public view returns(PerfomancePlanOrReportResponseBase memory){
        PerfomancePlanOrReportResponseBase memory response;
        response.identifier = address(this);
        response.name = name;
        response.description = description;
        response.otherInformation = otherInformation;
        response.strategeticPlanCore = getStrategeticPlanCoreResponseBase();
        response.administrativeInformation = administrativeInformation.getAdministrativeInformationResponse();
        response.sumbitter = sumbitter.getContactInformationResponse();
        response.reportType = reportType;
        return response;
    }
    function getPerfomancePlanOrReportResponse() public view returns(PerfomancePlanOrReportResponse memory){
        PerfomancePlanOrReportResponse memory response;
        response.base = getPerfomancePlanOrReportResponseBase();
        response.strategeticPlanCore = getStrategeticPlanCoreResponse();
        return response;
    }
    function getStrategeticPlanCoreResponseBase() public view returns(StrategeticPlanCoreResponseBase memory){
        StrategeticPlanCoreResponseBase memory response;
        response.organizations = organizations;
        response.vision = Vision(vision).getVisionResponse();
        response.mission = Mission(mission).getMissionResponse();
        response.values = values;
        response.goals = goals;
        return response;
    }
    function getStrategeticPlanCoreResponse() public view returns(StrategeticPlanCoreResponse memory){
        StrategeticPlanCoreResponse memory response;
        response.base = getStrategeticPlanCoreResponseBase();
        response.organizations = new OrganizationResponseBase[](organizations.length);
        for(uint i = 0; i < organizations.length; i++){
            Organization organization = Organization(organizations[i]);
            response.organizations[i] = organization.getOrganizationResponseBase();
        }
        response.goals = new GoalResponseBase[](goals.length);
        for(uint i = 0; i < goals.length; i++){
            Goal goal = Goal(goals[i]);
            response.goals[i] = goal.getGoalResponseBase();
        }
        return response;
    }

}
