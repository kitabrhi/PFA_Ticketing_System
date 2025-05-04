import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for NotificationsApiApi
void main() {
  final instance = Openapi().getNotificationsApiApi();

  group(NotificationsApiApi, () {
    //Future apiNotificationsApiIdMarkAsReadPatch(int id) async
    test('test apiNotificationsApiIdMarkAsReadPatch', () async {
      // TODO
    });

    //Future apiNotificationsApiPost({ String userId, String title, String message }) async
    test('test apiNotificationsApiPost', () async {
      // TODO
    });

    //Future<BuiltList<Notification>> apiNotificationsApiUserUserIdGet(String userId) async
    test('test apiNotificationsApiUserUserIdGet', () async {
      // TODO
    });

  });
}
