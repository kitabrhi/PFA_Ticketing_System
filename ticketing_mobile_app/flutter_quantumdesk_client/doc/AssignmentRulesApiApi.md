# openapi.api.AssignmentRulesApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAssignmentRulesApiApplyTicketIdPost**](AssignmentRulesApiApi.md#apiassignmentrulesapiapplyticketidpost) | **POST** /api/AssignmentRulesApi/Apply/{ticketId} | 
[**apiAssignmentRulesApiGet**](AssignmentRulesApiApi.md#apiassignmentrulesapiget) | **GET** /api/AssignmentRulesApi | 
[**apiAssignmentRulesApiIdDelete**](AssignmentRulesApiApi.md#apiassignmentrulesapiiddelete) | **DELETE** /api/AssignmentRulesApi/{id} | 
[**apiAssignmentRulesApiIdGet**](AssignmentRulesApiApi.md#apiassignmentrulesapiidget) | **GET** /api/AssignmentRulesApi/{id} | 
[**apiAssignmentRulesApiIdPut**](AssignmentRulesApiApi.md#apiassignmentrulesapiidput) | **PUT** /api/AssignmentRulesApi/{id} | 
[**apiAssignmentRulesApiPost**](AssignmentRulesApiApi.md#apiassignmentrulesapipost) | **POST** /api/AssignmentRulesApi | 


# **apiAssignmentRulesApiApplyTicketIdPost**
> apiAssignmentRulesApiApplyTicketIdPost(ticketId)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAssignmentRulesApiApi();
final int ticketId = 56; // int | 

try {
    api.apiAssignmentRulesApiApplyTicketIdPost(ticketId);
} catch on DioException (e) {
    print('Exception when calling AssignmentRulesApiApi->apiAssignmentRulesApiApplyTicketIdPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ticketId** | **int**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAssignmentRulesApiGet**
> BuiltList<AssignmentRule> apiAssignmentRulesApiGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAssignmentRulesApiApi();

try {
    final response = api.apiAssignmentRulesApiGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling AssignmentRulesApiApi->apiAssignmentRulesApiGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList&lt;AssignmentRule&gt;**](AssignmentRule.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAssignmentRulesApiIdDelete**
> apiAssignmentRulesApiIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAssignmentRulesApiApi();
final int id = 56; // int | 

try {
    api.apiAssignmentRulesApiIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling AssignmentRulesApiApi->apiAssignmentRulesApiIdDelete: $e\n');
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

# **apiAssignmentRulesApiIdGet**
> AssignmentRule apiAssignmentRulesApiIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAssignmentRulesApiApi();
final int id = 56; // int | 

try {
    final response = api.apiAssignmentRulesApiIdGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling AssignmentRulesApiApi->apiAssignmentRulesApiIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**AssignmentRule**](AssignmentRule.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAssignmentRulesApiIdPut**
> apiAssignmentRulesApiIdPut(id, assignmentRule)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAssignmentRulesApiApi();
final int id = 56; // int | 
final AssignmentRule assignmentRule = ; // AssignmentRule | 

try {
    api.apiAssignmentRulesApiIdPut(id, assignmentRule);
} catch on DioException (e) {
    print('Exception when calling AssignmentRulesApiApi->apiAssignmentRulesApiIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **assignmentRule** | [**AssignmentRule**](AssignmentRule.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAssignmentRulesApiPost**
> AssignmentRule apiAssignmentRulesApiPost(assignmentRule)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAssignmentRulesApiApi();
final AssignmentRule assignmentRule = ; // AssignmentRule | 

try {
    final response = api.apiAssignmentRulesApiPost(assignmentRule);
    print(response);
} catch on DioException (e) {
    print('Exception when calling AssignmentRulesApiApi->apiAssignmentRulesApiPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **assignmentRule** | [**AssignmentRule**](AssignmentRule.md)|  | [optional] 

### Return type

[**AssignmentRule**](AssignmentRule.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

