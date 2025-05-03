# openapi.api.NotificationsApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiNotificationsApiIdMarkAsReadPatch**](NotificationsApiApi.md#apinotificationsapiidmarkasreadpatch) | **PATCH** /api/NotificationsApi/{id}/MarkAsRead | 
[**apiNotificationsApiPost**](NotificationsApiApi.md#apinotificationsapipost) | **POST** /api/NotificationsApi | 
[**apiNotificationsApiUserUserIdGet**](NotificationsApiApi.md#apinotificationsapiuseruseridget) | **GET** /api/NotificationsApi/User/{userId} | 


# **apiNotificationsApiIdMarkAsReadPatch**
> apiNotificationsApiIdMarkAsReadPatch(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getNotificationsApiApi();
final int id = 56; // int | 

try {
    api.apiNotificationsApiIdMarkAsReadPatch(id);
} catch on DioException (e) {
    print('Exception when calling NotificationsApiApi->apiNotificationsApiIdMarkAsReadPatch: $e\n');
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

# **apiNotificationsApiPost**
> apiNotificationsApiPost(userId, title, message)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getNotificationsApiApi();
final String userId = userId_example; // String | 
final String title = title_example; // String | 
final String message = message_example; // String | 

try {
    api.apiNotificationsApiPost(userId, title, message);
} catch on DioException (e) {
    print('Exception when calling NotificationsApiApi->apiNotificationsApiPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | [optional] 
 **title** | **String**|  | [optional] 
 **message** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiNotificationsApiUserUserIdGet**
> BuiltList<Notification> apiNotificationsApiUserUserIdGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getNotificationsApiApi();
final String userId = userId_example; // String | 

try {
    final response = api.apiNotificationsApiUserUserIdGet(userId);
    print(response);
} catch on DioException (e) {
    print('Exception when calling NotificationsApiApi->apiNotificationsApiUserUserIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **String**|  | 

### Return type

[**BuiltList&lt;Notification&gt;**](Notification.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

