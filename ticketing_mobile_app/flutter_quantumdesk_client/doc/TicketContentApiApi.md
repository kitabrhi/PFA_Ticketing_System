# openapi.api.TicketContentApiApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiTicketContentApiAddCommentPost**](TicketContentApiApi.md#apiticketcontentapiaddcommentpost) | **POST** /api/TicketContentApi/AddComment | 
[**apiTicketContentApiDeleteAttachmentIdDelete**](TicketContentApiApi.md#apiticketcontentapideleteattachmentiddelete) | **DELETE** /api/TicketContentApi/DeleteAttachment/{id} | 
[**apiTicketContentApiDeleteCommentIdDelete**](TicketContentApiApi.md#apiticketcontentapideletecommentiddelete) | **DELETE** /api/TicketContentApi/DeleteComment/{id} | 
[**apiTicketContentApiDownloadAttachmentIdGet**](TicketContentApiApi.md#apiticketcontentapidownloadattachmentidget) | **GET** /api/TicketContentApi/DownloadAttachment/{id} | 
[**apiTicketContentApiEditCommentIdPut**](TicketContentApiApi.md#apiticketcontentapieditcommentidput) | **PUT** /api/TicketContentApi/EditComment/{id} | 
[**apiTicketContentApiUploadAttachmentPost**](TicketContentApiApi.md#apiticketcontentapiuploadattachmentpost) | **POST** /api/TicketContentApi/UploadAttachment | 


# **apiTicketContentApiAddCommentPost**
> apiTicketContentApiAddCommentPost(ticketId, commentText, isInternal)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketContentApiApi();
final int ticketId = 56; // int | 
final String commentText = commentText_example; // String | 
final bool isInternal = true; // bool | 

try {
    api.apiTicketContentApiAddCommentPost(ticketId, commentText, isInternal);
} catch on DioException (e) {
    print('Exception when calling TicketContentApiApi->apiTicketContentApiAddCommentPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ticketId** | **int**|  | [optional] 
 **commentText** | **String**|  | [optional] 
 **isInternal** | **bool**|  | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketContentApiDeleteAttachmentIdDelete**
> apiTicketContentApiDeleteAttachmentIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketContentApiApi();
final int id = 56; // int | 

try {
    api.apiTicketContentApiDeleteAttachmentIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling TicketContentApiApi->apiTicketContentApiDeleteAttachmentIdDelete: $e\n');
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

# **apiTicketContentApiDeleteCommentIdDelete**
> apiTicketContentApiDeleteCommentIdDelete(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketContentApiApi();
final int id = 56; // int | 

try {
    api.apiTicketContentApiDeleteCommentIdDelete(id);
} catch on DioException (e) {
    print('Exception when calling TicketContentApiApi->apiTicketContentApiDeleteCommentIdDelete: $e\n');
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

# **apiTicketContentApiDownloadAttachmentIdGet**
> apiTicketContentApiDownloadAttachmentIdGet(id)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketContentApiApi();
final int id = 56; // int | 

try {
    api.apiTicketContentApiDownloadAttachmentIdGet(id);
} catch on DioException (e) {
    print('Exception when calling TicketContentApiApi->apiTicketContentApiDownloadAttachmentIdGet: $e\n');
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

# **apiTicketContentApiEditCommentIdPut**
> apiTicketContentApiEditCommentIdPut(id, commentText, isInternal)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketContentApiApi();
final int id = 56; // int | 
final String commentText = commentText_example; // String | 
final bool isInternal = true; // bool | 

try {
    api.apiTicketContentApiEditCommentIdPut(id, commentText, isInternal);
} catch on DioException (e) {
    print('Exception when calling TicketContentApiApi->apiTicketContentApiEditCommentIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 
 **commentText** | **String**|  | [optional] 
 **isInternal** | **bool**|  | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiTicketContentApiUploadAttachmentPost**
> apiTicketContentApiUploadAttachmentPost(ticketId, file)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getTicketContentApiApi();
final int ticketId = 56; // int | 
final MultipartFile file = BINARY_DATA_HERE; // MultipartFile | 

try {
    api.apiTicketContentApiUploadAttachmentPost(ticketId, file);
} catch on DioException (e) {
    print('Exception when calling TicketContentApiApi->apiTicketContentApiUploadAttachmentPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ticketId** | **int**|  | [optional] 
 **file** | **MultipartFile**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

