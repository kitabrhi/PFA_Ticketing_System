//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/support_team.dart';
import 'package:openapi/src/model/user.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'team_member.g.dart';

/// TeamMember
///
/// Properties:
/// * [teamMemberID] 
/// * [teamID] 
/// * [userId] 
/// * [joinDate] 
/// * [team] 
/// * [user] 
@BuiltValue()
abstract class TeamMember implements Built<TeamMember, TeamMemberBuilder> {
  @BuiltValueField(wireName: r'teamMemberID')
  int? get teamMemberID;

  @BuiltValueField(wireName: r'teamID')
  int get teamID;

  @BuiltValueField(wireName: r'userId')
  String get userId;

  @BuiltValueField(wireName: r'joinDate')
  DateTime? get joinDate;

  @BuiltValueField(wireName: r'team')
  SupportTeam? get team;

  @BuiltValueField(wireName: r'user')
  User? get user;

  TeamMember._();

  factory TeamMember([void updates(TeamMemberBuilder b)]) = _$TeamMember;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(TeamMemberBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<TeamMember> get serializer => _$TeamMemberSerializer();
}

class _$TeamMemberSerializer implements PrimitiveSerializer<TeamMember> {
  @override
  final Iterable<Type> types = const [TeamMember, _$TeamMember];

  @override
  final String wireName = r'TeamMember';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    TeamMember object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.teamMemberID != null) {
      yield r'teamMemberID';
      yield serializers.serialize(
        object.teamMemberID,
        specifiedType: const FullType(int),
      );
    }
    yield r'teamID';
    yield serializers.serialize(
      object.teamID,
      specifiedType: const FullType(int),
    );
    yield r'userId';
    yield serializers.serialize(
      object.userId,
      specifiedType: const FullType(String),
    );
    if (object.joinDate != null) {
      yield r'joinDate';
      yield serializers.serialize(
        object.joinDate,
        specifiedType: const FullType(DateTime),
      );
    }
    if (object.team != null) {
      yield r'team';
      yield serializers.serialize(
        object.team,
        specifiedType: const FullType(SupportTeam),
      );
    }
    if (object.user != null) {
      yield r'user';
      yield serializers.serialize(
        object.user,
        specifiedType: const FullType(User),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    TeamMember object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required TeamMemberBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'teamMemberID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.teamMemberID = valueDes;
          break;
        case r'teamID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.teamID = valueDes;
          break;
        case r'userId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.userId = valueDes;
          break;
        case r'joinDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.joinDate = valueDes;
          break;
        case r'team':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(SupportTeam),
          ) as SupportTeam;
          result.team.replace(valueDes);
          break;
        case r'user':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.user.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  TeamMember deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = TeamMemberBuilder();
    final serializedList = (serialized as Iterable<Object?>).toList();
    final unhandled = <Object?>[];
    _deserializeProperties(
      serializers,
      serialized,
      specifiedType: specifiedType,
      serializedList: serializedList,
      unhandled: unhandled,
      result: result,
    );
    return result.build();
  }
}

