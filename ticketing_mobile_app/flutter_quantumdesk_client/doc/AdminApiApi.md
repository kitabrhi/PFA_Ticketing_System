# openapi.api.AdminApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAdminApiCreateUserGet**](AdminApiApi.md#apiadminapicreateuserget) | **GET** /api/AdminApi/CreateUser | 
[**apiAdminApiCreateUserPost**](AdminApiApi.md#apiadminapicreateuserpost) | **POST** /api/AdminApi/CreateUser | 
[**apiAdminApiDeleteUserConfirmedIdDelete**](AdminApiApi.md#apiadminapideleteuserconfirmediddelete) | **DELETE** /api/AdminApi/DeleteUserConfirmed/{id} | 
[**apiAdminApiDeleteUserIdGet**](AdminApiApi.md#apiadminapideleteuseridget) | **GET** /api/AdminApi/DeleteUser/{id} | 
[**apiAdminApiEditUserIdGet**](AdminApiApi.md#apiadminapiedituseridget) | **GET** /api/AdminApi/EditUser/{id} | 
[**apiAdminApiEditUserIdPut**](AdminApiApi.md#apiadminapiedituseridput) | **PUT** /api/AdminApi/EditUser/{id} | 
[**apiAdminApiUserDetailsIdGet**](AdminApiApi.md#apiadminapiuserdetailsidget) | **GET** /api/AdminApi/UserDetails/{id} | 
[**apiAdminApiUsersGet**](AdminApiApi.md#apiadminapiusersget) | **GET** /api/AdminApi/Users | 


# **apiAdminApiCreateUserGet**
> apiAdminApiCreateUserGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();

try {
    api.apiAdminApiCreateUserGet();
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiCreateUserGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAdminApiCreateUserPost**
> apiAdminApiCreateUserPost(createUserModel)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final CreateUserModel createUserModel = ; // CreateUserModel | 

try {
    api.apiAdminApiCreateUserPost(createUserModel);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiCreateUserPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createUserModel** | [**CreateUserModel**](CreateUserModel.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAdminApiDeleteUserConfirmedIdDelete**
> apiAdminApiDeleteUserConfirmedIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final String id = id_example; // String | 

try {
    api.apiAdminApiDeleteUserConfirmedIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiDeleteUserConfirmedIdDelete: $e\n');
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

# **apiAdminApiDeleteUserIdGet**
> apiAdminApiDeleteUserIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final String id = id_example; // String | 

try {
    api.apiAdminApiDeleteUserIdGet(id);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiDeleteUserIdGet: $e\n');
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

# **apiAdminApiEditUserIdGet**
> apiAdminApiEditUserIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final String id = id_example; // String | 

try {
    api.apiAdminApiEditUserIdGet(id);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiEditUserIdGet: $e\n');
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

# **apiAdminApiEditUserIdPut**
> apiAdminApiEditUserIdPut(id, editUserModel)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final String id = id_example; // String | 
final EditUserModel editUserModel = ; // EditUserModel | 

try {
    api.apiAdminApiEditUserIdPut(id, editUserModel);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiEditUserIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **editUserModel** | [**EditUserModel**](EditUserModel.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAdminApiUserDetailsIdGet**
> apiAdminApiUserDetailsIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final String id = id_example; // String | 

try {
    api.apiAdminApiUserDetailsIdGet(id);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiUserDetailsIdGet: $e\n');
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

# **apiAdminApiUsersGet**
> apiAdminApiUsersGet(searchTerm)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getAdminApiApi();
final String searchTerm = searchTerm_example; // String | 

try {
    api.apiAdminApiUsersGet(searchTerm);
} catch on DioException (e) {
    print('Exception when calling AdminApiApi->apiAdminApiUsersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **searchTerm** | **String**|  | [optional] [default to '']

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

