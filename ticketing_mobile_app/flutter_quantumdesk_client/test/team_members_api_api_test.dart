import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for TeamMembersApiApi
void main() {
  final instance = Openapi().getTeamMembersApiApi();

  group(TeamMembersApiApi, () {
    //Future<BuiltList<TeamMember>> apiTeamMembersApiGet() async
    test('test apiTeamMembersApiGet', () async {
      // TODO
    });

    //Future apiTeamMembersApiIdDelete(int id) async
    test('test apiTeamMembersApiIdDelete', () async {
      // TODO
    });

    //Future<TeamMember> apiTeamMembersApiIdGet(int id) async
    test('test apiTeamMembersApiIdGet', () async {
      // TODO
    });

    //Future apiTeamMembersApiIdPut(int id, { TeamMember teamMember }) async
    test('test apiTeamMembersApiIdPut', () async {
      // TODO
    });

    //Future<TeamMember> apiTeamMembersApiPost({ TeamMember teamMember }) async
    test('test apiTeamMembersApiPost', () async {
      // TODO
    });

  });
}
