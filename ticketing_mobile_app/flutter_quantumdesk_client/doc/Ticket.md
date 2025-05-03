# openapi.model.Ticket

## Load the model package
```dart
import 'package:openapi/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ticketID** | **int** |  | [optional] 
**title** | **String** |  | 
**description** | **String** |  | 
**category** | [**TicketCategory**](TicketCategory.md) |  | 
**priority** | [**TicketPriority**](TicketPriority.md) |  | 
**status** | [**TicketStatus**](TicketStatus.md) |  | 
**createdByUserId** | **String** |  | 
**assignedToUserId** | **String** |  | [optional] 
**assignedToTeamID** | **int** |  | [optional] 
**createdDate** | [**DateTime**](DateTime.md) |  | [optional] 
**updatedDate** | [**DateTime**](DateTime.md) |  | [optional] 
**dueDate** | [**DateTime**](DateTime.md) |  | [optional] 
**resolutionDate** | [**DateTime**](DateTime.md) |  | [optional] 
**closedDate** | [**DateTime**](DateTime.md) |  | [optional] 
**source_** | **String** |  | 
**isEscalated** | **bool** |  | [optional] 
**createdByUser** | [**User**](User.md) |  | [optional] 
**assignedToUser** | [**User**](User.md) |  | [optional] 
**assignedToTeam** | [**SupportTeam**](SupportTeam.md) |  | [optional] 
**ticketHistories** | [**BuiltList&lt;TicketHistory&gt;**](TicketHistory.md) |  | [optional] 
**ticketComments** | [**BuiltList&lt;TicketComment&gt;**](TicketComment.md) |  | [optional] 
**ticketAttachments** | [**BuiltList&lt;Attachment&gt;**](Attachment.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


