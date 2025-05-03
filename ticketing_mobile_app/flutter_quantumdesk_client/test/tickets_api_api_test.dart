import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for TicketsApiApi
void main() {
  final instance = Openapi().getTicketsApiApi();

  group(TicketsApiApi, () {
    //Future<BuiltList<Ticket>> apiTicketsApiAssignedTicketsGet({ String userId }) async
    test('test apiTicketsApiAssignedTicketsGet', () async {
      // TODO
    });

    //Future<BuiltList<Ticket>> apiTicketsApiGet() async
    test('test apiTicketsApiGet', () async {
      // TODO
    });

    //Future<Ticket> apiTicketsApiIdAssignTeamPatch(int id, { String updatedByUserId, int body }) async
    test('test apiTicketsApiIdAssignTeamPatch', () async {
      // TODO
    });

    //Future<Ticket> apiTicketsApiIdAssignUserPatch(int id, { String updatedByUserId, String body }) async
    test('test apiTicketsApiIdAssignUserPatch', () async {
      // TODO
    });

    //Future<BuiltList<Attachment>> apiTicketsApiIdAttachmentsGet(int id) async
    test('test apiTicketsApiIdAttachmentsGet', () async {
      // TODO
    });

    //Future<BuiltList<TicketComment>> apiTicketsApiIdCommentsGet(int id) async
    test('test apiTicketsApiIdCommentsGet', () async {
      // TODO
    });

    //Future<TicketComment> apiTicketsApiIdCommentsPost(int id, { TicketComment ticketComment }) async
    test('test apiTicketsApiIdCommentsPost', () async {
      // TODO
    });

    //Future apiTicketsApiIdDelete(int id) async
    test('test apiTicketsApiIdDelete', () async {
      // TODO
    });

    //Future<Ticket> apiTicketsApiIdGet(int id) async
    test('test apiTicketsApiIdGet', () async {
      // TODO
    });

    //Future<BuiltList<TicketHistory>> apiTicketsApiIdHistoryGet(int id) async
    test('test apiTicketsApiIdHistoryGet', () async {
      // TODO
    });

    //Future apiTicketsApiIdPut(int id, { Ticket ticket }) async
    test('test apiTicketsApiIdPut', () async {
      // TODO
    });

    //Future<Ticket> apiTicketsApiIdStatusPatch(int id, { String userId, int body }) async
    test('test apiTicketsApiIdStatusPatch', () async {
      // TODO
    });

    //Future<BuiltList<Ticket>> apiTicketsApiMyTicketsGet({ String userId }) async
    test('test apiTicketsApiMyTicketsGet', () async {
      // TODO
    });

    //Future<Ticket> apiTicketsApiPost({ Ticket ticket }) async
    test('test apiTicketsApiPost', () async {
      // TODO
    });

  });
}
