# openapi.api.EscalationRulesApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiEscalationRulesApiEscalateTicketIdPost**](EscalationRulesApiApi.md#apiescalationrulesapiescalateticketidpost) | **POST** /api/EscalationRulesApi/Escalate/{ticketId} | 
[**apiEscalationRulesApiGet**](EscalationRulesApiApi.md#apiescalationrulesapiget) | **GET** /api/EscalationRulesApi | 
[**apiEscalationRulesApiIdDelete**](EscalationRulesApiApi.md#apiescalationrulesapiiddelete) | **DELETE** /api/EscalationRulesApi/{id} | 
[**apiEscalationRulesApiIdGet**](EscalationRulesApiApi.md#apiescalationrulesapiidget) | **GET** /api/EscalationRulesApi/{id} | 
[**apiEscalationRulesApiIdPut**](EscalationRulesApiApi.md#apiescalationrulesapiidput) | **PUT** /api/EscalationRulesApi/{id} | 
[**apiEscalationRulesApiPost**](EscalationRulesApiApi.md#apiescalationrulesapipost) | **POST** /api/EscalationRulesApi | 
[**apiEscalationRulesApiTicketsNeedingEscalationGet**](EscalationRulesApiApi.md#apiescalationrulesapiticketsneedingescalationget) | **GET** /api/EscalationRulesApi/TicketsNeedingEscalation | 


# **apiEscalationRulesApiEscalateTicketIdPost**
> apiEscalationRulesApiEscalateTicketIdPost(ticketId)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();
final int ticketId = 56; // int | 

try {
    api.apiEscalationRulesApiEscalateTicketIdPost(ticketId);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiEscalateTicketIdPost: $e\n');
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

# **apiEscalationRulesApiGet**
> BuiltList<EscalationRule> apiEscalationRulesApiGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();

try {
    final response = api.apiEscalationRulesApiGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList&lt;EscalationRule&gt;**](EscalationRule.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiEscalationRulesApiIdDelete**
> apiEscalationRulesApiIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();
final int id = 56; // int | 

try {
    api.apiEscalationRulesApiIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiIdDelete: $e\n');
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

# **apiEscalationRulesApiIdGet**
> EscalationRule apiEscalationRulesApiIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();
final int id = 56; // int | 

try {
    final response = api.apiEscalationRulesApiIdGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**EscalationRule**](EscalationRule.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiEscalationRulesApiIdPut**
> apiEscalationRulesApiIdPut(id, escalationRule)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();
final int id = 56; // int | 
final EscalationRule escalationRule = ; // EscalationRule | 

try {
    api.apiEscalationRulesApiIdPut(id, escalationRule);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **escalationRule** | [**EscalationRule**](EscalationRule.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiEscalationRulesApiPost**
> EscalationRule apiEscalationRulesApiPost(escalationRule)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();
final EscalationRule escalationRule = ; // EscalationRule | 

try {
    final response = api.apiEscalationRulesApiPost(escalationRule);
    print(response);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **escalationRule** | [**EscalationRule**](EscalationRule.md)|  | [optional] 

### Return type

[**EscalationRule**](EscalationRule.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiEscalationRulesApiTicketsNeedingEscalationGet**
> BuiltList<Ticket> apiEscalationRulesApiTicketsNeedingEscalationGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getEscalationRulesApiApi();

try {
    final response = api.apiEscalationRulesApiTicketsNeedingEscalationGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling EscalationRulesApiApi->apiEscalationRulesApiTicketsNeedingEscalationGet: $e\n');
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

