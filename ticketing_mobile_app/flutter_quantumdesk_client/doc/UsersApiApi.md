# openapi.api.UsersApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiUsersApiGet**](UsersApiApi.md#apiusersapiget) | **GET** /api/UsersApi | 
[**apiUsersApiIdDeactivatePatch**](UsersApiApi.md#apiusersapiiddeactivatepatch) | **PATCH** /api/UsersApi/{id}/Deactivate | 
[**apiUsersApiIdDelete**](UsersApiApi.md#apiusersapiiddelete) | **DELETE** /api/UsersApi/{id} | 
[**apiUsersApiIdGet**](UsersApiApi.md#apiusersapiidget) | **GET** /api/UsersApi/{id} | 
[**apiUsersApiIdPut**](UsersApiApi.md#apiusersapiidput) | **PUT** /api/UsersApi/{id} | 
[**apiUsersApiRoleRoleNameGet**](UsersApiApi.md#apiusersapirolerolenameget) | **GET** /api/UsersApi/Role/{roleName} | 


# **apiUsersApiGet**
> BuiltList<User> apiUsersApiGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUsersApiApi();

try {
    final response = api.apiUsersApiGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling UsersApiApi->apiUsersApiGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList&lt;User&gt;**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUsersApiIdDeactivatePatch**
> apiUsersApiIdDeactivatePatch(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUsersApiApi();
final String id = id_example; // String | 

try {
    api.apiUsersApiIdDeactivatePatch(id);
} catch on DioException (e) {
    print('Exception when calling UsersApiApi->apiUsersApiIdDeactivatePatch: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUsersApiIdDelete**
> apiUsersApiIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUsersApiApi();
final String id = id_example; // String | 

try {
    api.apiUsersApiIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling UsersApiApi->apiUsersApiIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUsersApiIdGet**
> User apiUsersApiIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUsersApiApi();
final String id = id_example; // String | 

try {
    final response = api.apiUsersApiIdGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling UsersApiApi->apiUsersApiIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUsersApiIdPut**
> apiUsersApiIdPut(id, user)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUsersApiApi();
final String id = id_example; // String | 
final User user = ; // User | 

try {
    api.apiUsersApiIdPut(id, user);
} catch on DioException (e) {
    print('Exception when calling UsersApiApi->apiUsersApiIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **user** | [**User**](User.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiUsersApiRoleRoleNameGet**
> BuiltList<User> apiUsersApiRoleRoleNameGet(roleName)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUsersApiApi();
final String roleName = roleName_example; // String | 

try {
    final response = api.apiUsersApiRoleRoleNameGet(roleName);
    print(response);
} catch on DioException (e) {
    print('Exception when calling UsersApiApi->apiUsersApiRoleRoleNameGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleName** | **String**|  | 

### Return type

[**BuiltList&lt;User&gt;**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

