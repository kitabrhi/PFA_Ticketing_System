//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_collection/built_collection.dart';
import 'package:openapi/src/model/user.dart';
import 'package:openapi/src/model/team_member.dart';
import 'package:openapi/src/model/ticket.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'support_team.g.dart';

/// SupportTeam
///
/// Properties:
/// * [teamID] 
/// * [teamName] 
/// * [description] 
/// * [managerId] 
/// * [manager] 
/// * [teamMembers] 
/// * [assignedTickets] 
@BuiltValue()
abstract class SupportTeam implements Built<SupportTeam, SupportTeamBuilder> {
  @BuiltValueField(wireName: r'teamID')
  int? get teamID;

  @BuiltValueField(wireName: r'teamName')
  String get teamName;

  @BuiltValueField(wireName: r'description')
  String? get description;

  @BuiltValueField(wireName: r'managerId')
  String? get managerId;

  @BuiltValueField(wireName: r'manager')
  User? get manager;

  @BuiltValueField(wireName: r'teamMembers')
  BuiltList<TeamMember>? get teamMembers;

  @BuiltValueField(wireName: r'assignedTickets')
  BuiltList<Ticket>? get assignedTickets;

  SupportTeam._();

  factory SupportTeam([void updates(SupportTeamBuilder b)]) = _$SupportTeam;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(SupportTeamBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<SupportTeam> get serializer => _$SupportTeamSerializer();
}

class _$SupportTeamSerializer implements PrimitiveSerializer<SupportTeam> {
  @override
  final Iterable<Type> types = const [SupportTeam, _$SupportTeam];

  @override
  final String wireName = r'SupportTeam';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    SupportTeam object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.teamID != null) {
      yield r'teamID';
      yield serializers.serialize(
        object.teamID,
        specifiedType: const FullType(int),
      );
    }
    yield r'teamName';
    yield serializers.serialize(
      object.teamName,
      specifiedType: const FullType(String),
    );
    if (object.description != null) {
      yield r'description';
      yield serializers.serialize(
        object.description,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.managerId != null) {
      yield r'managerId';
      yield serializers.serialize(
        object.managerId,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.manager != null) {
      yield r'manager';
      yield serializers.serialize(
        object.manager,
        specifiedType: const FullType(User),
      );
    }
    if (object.teamMembers != null) {
      yield r'teamMembers';
      yield serializers.serialize(
        object.teamMembers,
        specifiedType: const FullType.nullable(BuiltList, [FullType(TeamMember)]),
      );
    }
    if (object.assignedTickets != null) {
      yield r'assignedTickets';
      yield serializers.serialize(
        object.assignedTickets,
        specifiedType: const FullType.nullable(BuiltList, [FullType(Ticket)]),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    SupportTeam object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required SupportTeamBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'teamID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.teamID = valueDes;
          break;
        case r'teamName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.teamName = valueDes;
          break;
        case r'description':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.description = valueDes;
          break;
        case r'managerId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.managerId = valueDes;
          break;
        case r'manager':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.manager.replace(valueDes);
          break;
        case r'teamMembers':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(TeamMember)]),
          ) as BuiltList<TeamMember>?;
          if (valueDes == null) continue;
          result.teamMembers.replace(valueDes);
          break;
        case r'assignedTickets':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(Ticket)]),
          ) as BuiltList<Ticket>?;
          if (valueDes == null) continue;
          result.assignedTickets.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  SupportTeam deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = SupportTeamBuilder();
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

