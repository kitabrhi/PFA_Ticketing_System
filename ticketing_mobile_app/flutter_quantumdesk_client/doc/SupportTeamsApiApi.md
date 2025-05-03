# openapi.api.SupportTeamsApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiSupportTeamsApiGet**](SupportTeamsApiApi.md#apisupportteamsapiget) | **GET** /api/SupportTeamsApi | 
[**apiSupportTeamsApiIdDelete**](SupportTeamsApiApi.md#apisupportteamsapiiddelete) | **DELETE** /api/SupportTeamsApi/{id} | 
[**apiSupportTeamsApiIdGet**](SupportTeamsApiApi.md#apisupportteamsapiidget) | **GET** /api/SupportTeamsApi/{id} | 
[**apiSupportTeamsApiIdPut**](SupportTeamsApiApi.md#apisupportteamsapiidput) | **PUT** /api/SupportTeamsApi/{id} | 
[**apiSupportTeamsApiPost**](SupportTeamsApiApi.md#apisupportteamsapipost) | **POST** /api/SupportTeamsApi | 


# **apiSupportTeamsApiGet**
> BuiltList<SupportTeam> apiSupportTeamsApiGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSupportTeamsApiApi();

try {
    final response = api.apiSupportTeamsApiGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling SupportTeamsApiApi->apiSupportTeamsApiGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList&lt;SupportTeam&gt;**](SupportTeam.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSupportTeamsApiIdDelete**
> apiSupportTeamsApiIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSupportTeamsApiApi();
final int id = 56; // int | 

try {
    api.apiSupportTeamsApiIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling SupportTeamsApiApi->apiSupportTeamsApiIdDelete: $e\n');
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

# **apiSupportTeamsApiIdGet**
> SupportTeam apiSupportTeamsApiIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSupportTeamsApiApi();
final int id = 56; // int | 

try {
    final response = api.apiSupportTeamsApiIdGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling SupportTeamsApiApi->apiSupportTeamsApiIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**SupportTeam**](SupportTeam.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSupportTeamsApiIdPut**
> apiSupportTeamsApiIdPut(id, supportTeam)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSupportTeamsApiApi();
final int id = 56; // int | 
final SupportTeam supportTeam = ; // SupportTeam | 

try {
    api.apiSupportTeamsApiIdPut(id, supportTeam);
} catch on DioException (e) {
    print('Exception when calling SupportTeamsApiApi->apiSupportTeamsApiIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **supportTeam** | [**SupportTeam**](SupportTeam.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSupportTeamsApiPost**
> SupportTeam apiSupportTeamsApiPost(supportTeam)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getSupportTeamsApiApi();
final SupportTeam supportTeam = ; // SupportTeam | 

try {
    final response = api.apiSupportTeamsApiPost(supportTeam);
    print(response);
} catch on DioException (e) {
    print('Exception when calling SupportTeamsApiApi->apiSupportTeamsApiPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **supportTeam** | [**SupportTeam**](SupportTeam.md)|  | [optional] 

### Return type

[**SupportTeam**](SupportTeam.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

