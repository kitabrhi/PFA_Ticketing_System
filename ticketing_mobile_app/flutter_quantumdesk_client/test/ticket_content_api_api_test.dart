import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for TicketContentApiApi
void main() {
  final instance = Openapi().getTicketContentApiApi();

  group(TicketContentApiApi, () {
    //Future apiTicketContentApiAddCommentPost({ int ticketId, String commentText, bool isInternal }) async
    test('test apiTicketContentApiAddCommentPost', () async {
      // TODO
    });

    //Future apiTicketContentApiDeleteAttachmentIdDelete(int id) async
    test('test apiTicketContentApiDeleteAttachmentIdDelete', () async {
      // TODO
    });

    //Future apiTicketContentApiDeleteCommentIdDelete(int id) async
    test('test apiTicketContentApiDeleteCommentIdDelete', () async {
      // TODO
    });

    //Future apiTicketContentApiDownloadAttachmentIdGet(int id) async
    test('test apiTicketContentApiDownloadAttachmentIdGet', () async {
      // TODO
    });

    //Future apiTicketContentApiEditCommentIdPut(int id, { String commentText, bool isInternal }) async
    test('test apiTicketContentApiEditCommentIdPut', () async {
      // TODO
    });

    //Future apiTicketContentApiUploadAttachmentPost({ int ticketId, MultipartFile file }) async
    test('test apiTicketContentApiUploadAttachmentPost', () async {
      // TODO
    });

  });
}
