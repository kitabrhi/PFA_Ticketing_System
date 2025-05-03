# openapi.model.EscalationRule

## Load the model package
```dart
import 'package:openapi/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ruleID** | **int** |  | [optional] 
**ruleName** | **String** |  | 
**description** | **String** |  | [optional] 
**priority** | [**TicketPriority**](TicketPriority.md) |  | [optional] 
**status** | [**TicketStatus**](TicketStatus.md) |  | [optional] 
**escalateAfterHours** | **int** |  | 
**escalateToUserID** | **String** |  | [optional] 
**escalateToTeamID** | **int** |  | [optional] 
**notifyUserIDs** | **String** |  | [optional] 
**isActive** | **bool** |  | 
**escalateToUser** | [**User**](User.md) |  | [optional] 
**escalateToTeam** | [**SupportTeam**](SupportTeam.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


