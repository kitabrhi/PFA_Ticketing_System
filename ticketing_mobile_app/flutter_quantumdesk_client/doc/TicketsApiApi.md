# openapi.api.TicketsApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiTicketsApiAssignedTicketsGet**](TicketsApiApi.md#apiticketsapiassignedticketsget) | **GET** /api/TicketsApi/AssignedTickets | 
[**apiTicketsApiGet**](TicketsApiApi.md#apiticketsapiget) | **GET** /api/TicketsApi | 
[**apiTicketsApiIdAssignTeamPatch**](TicketsApiApi.md#apiticketsapiidassignteampatch) | **PATCH** /api/TicketsApi/{id}/AssignTeam | 
[**apiTicketsApiIdAssignUserPatch**](TicketsApiApi.md#apiticketsapiidassignuserpatch) | **PATCH** /api/TicketsApi/{id}/AssignUser | 
[**apiTicketsApiIdAttachmentsGet**](TicketsApiApi.md#apiticketsapiidattachmentsget) | **GET** /api/TicketsApi/{id}/Attachments | 
[**apiTicketsApiIdCommentsGet**](TicketsApiApi.md#apiticketsapiidcommentsget) | **GET** /api/TicketsApi/{id}/Comments | 
[**apiTicketsApiIdCommentsPost**](TicketsApiApi.md#apiticketsapiidcommentspost) | **POST** /api/TicketsApi/{id}/Comments | 
[**apiTicketsApiIdDelete**](TicketsApiApi.md#apiticketsapiiddelete) | **DELETE** /api/TicketsApi/{id} | 
[**apiTicketsApiIdGet**](TicketsApiApi.md#apiticketsapiidget) | **GET** /api/TicketsApi/{id} | 
[**apiTicketsApiIdHistoryGet**](TicketsApiApi.md#apiticketsapiidhistoryget) | **GET** /api/TicketsApi/{id}/History | 
[**apiTicketsApiIdPut**](TicketsApiApi.md#apiticketsapiidput) | **PUT** /api/TicketsApi/{id} | 
[**apiTicketsApiIdStatusPatch**](TicketsApiApi.md#apiticketsapiidstatuspatch) | **PATCH** /api/TicketsApi/{id}/Status | 
[**apiTicketsApiMyTicketsGet**](TicketsApiApi.md#apiticketsapimyticketsget) | **GET** /api/TicketsApi/MyTickets | 
[**apiTicketsApiPost**](TicketsApiApi.md#apiticketsapipost) | **POST** /api/TicketsApi | 


# **apiTicketsApiAssignedTicketsGet**
> BuiltList<Ticket> apiTicketsApiAssignedTicketsGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final String userId = userId_example; // String | 

try {
    final response = api.apiTicketsApiAssignedTicketsGet(userId);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiAssignedTicketsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | [optional] 

### Return type

[**BuiltList&lt;Ticket&gt;**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiGet**
> BuiltList<Ticket> apiTicketsApiGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();

try {
    final response = api.apiTicketsApiGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList&lt;Ticket&gt;**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdAssignTeamPatch**
> Ticket apiTicketsApiIdAssignTeamPatch(id, updatedByUserId, body)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 
final String updatedByUserId = updatedByUserId_example; // String | 
final int body = 56; // int | 

try {
    final response = api.apiTicketsApiIdAssignTeamPatch(id, updatedByUserId, body);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdAssignTeamPatch: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **updatedByUserId** | **String**|  | [optional] 
 **body** | **int**|  | [optional] 

### Return type

[**Ticket**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdAssignUserPatch**
> Ticket apiTicketsApiIdAssignUserPatch(id, updatedByUserId, body)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 
final String updatedByUserId = updatedByUserId_example; // String | 
final String body = body_example; // String | 

try {
    final response = api.apiTicketsApiIdAssignUserPatch(id, updatedByUserId, body);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdAssignUserPatch: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **updatedByUserId** | **String**|  | [optional] 
 **body** | **String**|  | [optional] 

### Return type

[**Ticket**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdAttachmentsGet**
> BuiltList<Attachment> apiTicketsApiIdAttachmentsGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 

try {
    final response = api.apiTicketsApiIdAttachmentsGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdAttachmentsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**BuiltList&lt;Attachment&gt;**](Attachment.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdCommentsGet**
> BuiltList<TicketComment> apiTicketsApiIdCommentsGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 

try {
    final response = api.apiTicketsApiIdCommentsGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdCommentsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**BuiltList&lt;TicketComment&gt;**](TicketComment.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdCommentsPost**
> TicketComment apiTicketsApiIdCommentsPost(id, ticketComment)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 
final TicketComment ticketComment = ; // TicketComment | 

try {
    final response = api.apiTicketsApiIdCommentsPost(id, ticketComment);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdCommentsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **ticketComment** | [**TicketComment**](TicketComment.md)|  | [optional] 

### Return type

[**TicketComment**](TicketComment.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdDelete**
> apiTicketsApiIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 

try {
    api.apiTicketsApiIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdGet**
> Ticket apiTicketsApiIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 

try {
    final response = api.apiTicketsApiIdGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**Ticket**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdHistoryGet**
> BuiltList<TicketHistory> apiTicketsApiIdHistoryGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 

try {
    final response = api.apiTicketsApiIdHistoryGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdHistoryGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**BuiltList&lt;TicketHistory&gt;**](TicketHistory.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdPut**
> apiTicketsApiIdPut(id, ticket)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 
final Ticket ticket = ; // Ticket | 

try {
    api.apiTicketsApiIdPut(id, ticket);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **ticket** | [**Ticket**](Ticket.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiIdStatusPatch**
> Ticket apiTicketsApiIdStatusPatch(id, userId, body)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final int id = 56; // int | 
final String userId = userId_example; // String | 
final int body = 56; // int | 

try {
    final response = api.apiTicketsApiIdStatusPatch(id, userId, body);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiIdStatusPatch: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **userId** | **String**|  | [optional] 
 **body** | **int**|  | [optional] 

### Return type

[**Ticket**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiMyTicketsGet**
> BuiltList<Ticket> apiTicketsApiMyTicketsGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final String userId = userId_example; // String | 

try {
    final response = api.apiTicketsApiMyTicketsGet(userId);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiMyTicketsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | [optional] 

### Return type

[**BuiltList&lt;Ticket&gt;**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketsApiPost**
> Ticket apiTicketsApiPost(ticket)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketsApiApi();
final Ticket ticket = ; // Ticket | 

try {
    final response = api.apiTicketsApiPost(ticket);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TicketsApiApi->apiTicketsApiPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ticket** | [**Ticket**](Ticket.md)|  | [optional] 

### Return type

[**Ticket**](Ticket.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

