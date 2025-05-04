# openapi.api.TeamMembersApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiTeamMembersApiGet**](TeamMembersApiApi.md#apiteammembersapiget) | **GET** /api/TeamMembersApi | 
[**apiTeamMembersApiIdDelete**](TeamMembersApiApi.md#apiteammembersapiiddelete) | **DELETE** /api/TeamMembersApi/{id} | 
[**apiTeamMembersApiIdGet**](TeamMembersApiApi.md#apiteammembersapiidget) | **GET** /api/TeamMembersApi/{id} | 
[**apiTeamMembersApiIdPut**](TeamMembersApiApi.md#apiteammembersapiidput) | **PUT** /api/TeamMembersApi/{id} | 
[**apiTeamMembersApiPost**](TeamMembersApiApi.md#apiteammembersapipost) | **POST** /api/TeamMembersApi | 


# **apiTeamMembersApiGet**
> BuiltList<TeamMember> apiTeamMembersApiGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTeamMembersApiApi();

try {
    final response = api.apiTeamMembersApiGet();
    print(response);
} catch on DioException (e) {
    print('Exception when calling TeamMembersApiApi->apiTeamMembersApiGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList&lt;TeamMember&gt;**](TeamMember.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTeamMembersApiIdDelete**
> apiTeamMembersApiIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTeamMembersApiApi();
final int id = 56; // int | 

try {
    api.apiTeamMembersApiIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling TeamMembersApiApi->apiTeamMembersApiIdDelete: $e\n');
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

# **apiTeamMembersApiIdGet**
> TeamMember apiTeamMembersApiIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTeamMembersApiApi();
final int id = 56; // int | 

try {
    final response = api.apiTeamMembersApiIdGet(id);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TeamMembersApiApi->apiTeamMembersApiIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**TeamMember**](TeamMember.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTeamMembersApiIdPut**
> apiTeamMembersApiIdPut(id, teamMember)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTeamMembersApiApi();
final int id = 56; // int | 
final TeamMember teamMember = ; // TeamMember | 

try {
    api.apiTeamMembersApiIdPut(id, teamMember);
} catch on DioException (e) {
    print('Exception when calling TeamMembersApiApi->apiTeamMembersApiIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **teamMember** | [**TeamMember**](TeamMember.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTeamMembersApiPost**
> TeamMember apiTeamMembersApiPost(teamMember)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTeamMembersApiApi();
final TeamMember teamMember = ; // TeamMember | 

try {
    final response = api.apiTeamMembersApiPost(teamMember);
    print(response);
} catch on DioException (e) {
    print('Exception when calling TeamMembersApiApi->apiTeamMembersApiPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **teamMember** | [**TeamMember**](TeamMember.md)|  | [optional] 

### Return type

[**TeamMember**](TeamMember.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

