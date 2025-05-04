//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/ticket_status.dart';
import 'package:openapi/src/model/support_team.dart';
import 'package:openapi/src/model/ticket_priority.dart';
import 'package:openapi/src/model/user.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'escalation_rule.g.dart';

/// EscalationRule
///
/// Properties:
/// * [ruleID] 
/// * [ruleName] 
/// * [description] 
/// * [priority] 
/// * [status] 
/// * [escalateAfterHours] 
/// * [escalateToUserID] 
/// * [escalateToTeamID] 
/// * [notifyUserIDs] 
/// * [isActive] 
/// * [escalateToUser] 
/// * [escalateToTeam] 
@BuiltValue()
abstract class EscalationRule implements Built<EscalationRule, EscalationRuleBuilder> {
  @BuiltValueField(wireName: r'ruleID')
  int? get ruleID;

  @BuiltValueField(wireName: r'ruleName')
  String get ruleName;

  @BuiltValueField(wireName: r'description')
  String? get description;

  @BuiltValueField(wireName: r'priority')
  TicketPriority? get priority;
  // enum priorityEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'status')
  TicketStatus? get status;
  // enum statusEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'escalateAfterHours')
  int get escalateAfterHours;

  @BuiltValueField(wireName: r'escalateToUserID')
  String? get escalateToUserID;

  @BuiltValueField(wireName: r'escalateToTeamID')
  int? get escalateToTeamID;

  @BuiltValueField(wireName: r'notifyUserIDs')
  String? get notifyUserIDs;

  @BuiltValueField(wireName: r'isActive')
  bool get isActive;

  @BuiltValueField(wireName: r'escalateToUser')
  User? get escalateToUser;

  @BuiltValueField(wireName: r'escalateToTeam')
  SupportTeam? get escalateToTeam;

  EscalationRule._();

  factory EscalationRule([void updates(EscalationRuleBuilder b)]) = _$EscalationRule;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(EscalationRuleBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<EscalationRule> get serializer => _$EscalationRuleSerializer();
}

class _$EscalationRuleSerializer implements PrimitiveSerializer<EscalationRule> {
  @override
  final Iterable<Type> types = const [EscalationRule, _$EscalationRule];

  @override
  final String wireName = r'EscalationRule';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    EscalationRule object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.ruleID != null) {
      yield r'ruleID';
      yield serializers.serialize(
        object.ruleID,
        specifiedType: const FullType(int),
      );
    }
    yield r'ruleName';
    yield serializers.serialize(
      object.ruleName,
      specifiedType: const FullType(String),
    );
    if (object.description != null) {
      yield r'description';
      yield serializers.serialize(
        object.description,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.priority != null) {
      yield r'priority';
      yield serializers.serialize(
        object.priority,
        specifiedType: const FullType(TicketPriority),
      );
    }
    if (object.status != null) {
      yield r'status';
      yield serializers.serialize(
        object.status,
        specifiedType: const FullType(TicketStatus),
      );
    }
    yield r'escalateAfterHours';
    yield serializers.serialize(
      object.escalateAfterHours,
      specifiedType: const FullType(int),
    );
    if (object.escalateToUserID != null) {
      yield r'escalateToUserID';
      yield serializers.serialize(
        object.escalateToUserID,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.escalateToTeamID != null) {
      yield r'escalateToTeamID';
      yield serializers.serialize(
        object.escalateToTeamID,
        specifiedType: const FullType.nullable(int),
      );
    }
    if (object.notifyUserIDs != null) {
      yield r'notifyUserIDs';
      yield serializers.serialize(
        object.notifyUserIDs,
        specifiedType: const FullType.nullable(String),
      );
    }
    yield r'isActive';
    yield serializers.serialize(
      object.isActive,
      specifiedType: const FullType(bool),
    );
    if (object.escalateToUser != null) {
      yield r'escalateToUser';
      yield serializers.serialize(
        object.escalateToUser,
        specifiedType: const FullType(User),
      );
    }
    if (object.escalateToTeam != null) {
      yield r'escalateToTeam';
      yield serializers.serialize(
        object.escalateToTeam,
        specifiedType: const FullType(SupportTeam),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    EscalationRule object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required EscalationRuleBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'ruleID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ruleID = valueDes;
          break;
        case r'ruleName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.ruleName = valueDes;
          break;
        case r'description':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.description = valueDes;
          break;
        case r'priority':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(TicketPriority),
          ) as TicketPriority;
          result.priority = valueDes;
          break;
        case r'status':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(TicketStatus),
          ) as TicketStatus;
          result.status = valueDes;
          break;
        case r'escalateAfterHours':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.escalateAfterHours = valueDes;
          break;
        case r'escalateToUserID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.escalateToUserID = valueDes;
          break;
        case r'escalateToTeamID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(int),
          ) as int?;
          if (valueDes == null) continue;
          result.escalateToTeamID = valueDes;
          break;
        case r'notifyUserIDs':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.notifyUserIDs = valueDes;
          break;
        case r'isActive':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.isActive = valueDes;
          break;
        case r'escalateToUser':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.escalateToUser.replace(valueDes);
          break;
        case r'escalateToTeam':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(SupportTeam),
          ) as SupportTeam;
          result.escalateToTeam.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  EscalationRule deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = EscalationRuleBuilder();
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

