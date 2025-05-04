# openapi.model.User

## Load the model package
```dart
import 'package:openapi/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **String** |  | [optional] 
**userName** | **String** |  | [optional] 
**normalizedUserName** | **String** |  | [optional] 
**email** | **String** |  | [optional] 
**normalizedEmail** | **String** |  | [optional] 
**emailConfirmed** | **bool** |  | [optional] 
**passwordHash** | **String** |  | [optional] 
**securityStamp** | **String** |  | [optional] 
**concurrencyStamp** | **String** |  | [optional] 
**phoneNumber** | **String** |  | [optional] 
**phoneNumberConfirmed** | **bool** |  | [optional] 
**twoFactorEnabled** | **bool** |  | [optional] 
**lockoutEnd** | [**DateTime**](DateTime.md) |  | [optional] 
**lockoutEnabled** | **bool** |  | [optional] 
**accessFailedCount** | **int** |  | [optional] 
**firstName** | **String** |  | [optional] 
**lastName** | **String** |  | [optional] 
**createdDate** | [**DateTime**](DateTime.md) |  | 
**lastLoginDate** | [**DateTime**](DateTime.md) |  | [optional] 
**isActive** | **bool** |  | 
**createdTickets** | [**BuiltList&lt;Ticket&gt;**](Ticket.md) |  | [optional] 
**assignedTickets** | [**BuiltList&lt;Ticket&gt;**](Ticket.md) |  | [optional] 
**managedTeams** | [**BuiltList&lt;SupportTeam&gt;**](SupportTeam.md) |  | [optional] 
**teamMemberships** | [**BuiltList&lt;TeamMember&gt;**](TeamMember.md) |  | [optional] 
**comments** | [**BuiltList&lt;TicketComment&gt;**](TicketComment.md) |  | [optional] 
**attachments** | [**BuiltList&lt;Attachment&gt;**](Attachment.md) |  | [optional] 
**ticketChanges** | [**BuiltList&lt;TicketHistory&gt;**](TicketHistory.md) |  | [optional] 
**articles** | [**BuiltList&lt;KnowledgeBaseArticle&gt;**](KnowledgeBaseArticle.md) |  | [optional] 
**notifications** | [**BuiltList&lt;Notification&gt;**](Notification.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


