//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/support_team.dart';
import 'package:openapi/src/model/ticket_priority.dart';
import 'package:openapi/src/model/user.dart';
import 'package:openapi/src/model/ticket_category.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_rule.g.dart';

/// AssignmentRule
///
/// Properties:
/// * [ruleID] 
/// * [ruleName] 
/// * [description] 
/// * [category] 
/// * [priority] 
/// * [assignToTeamID] 
/// * [assignToUserID] 
/// * [isActive] 
/// * [ruleOrder] 
/// * [assignToTeam] 
/// * [assignToUser] 
@BuiltValue()
abstract class AssignmentRule implements Built<AssignmentRule, AssignmentRuleBuilder> {
  @BuiltValueField(wireName: r'ruleID')
  int? get ruleID;

  @BuiltValueField(wireName: r'ruleName')
  String get ruleName;

  @BuiltValueField(wireName: r'description')
  String? get description;

  @BuiltValueField(wireName: r'category')
  TicketCategory? get category;
  // enum categoryEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'priority')
  TicketPriority? get priority;
  // enum priorityEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'assignToTeamID')
  int? get assignToTeamID;

  @BuiltValueField(wireName: r'assignToUserID')
  String? get assignToUserID;

  @BuiltValueField(wireName: r'isActive')
  bool get isActive;

  @BuiltValueField(wireName: r'ruleOrder')
  int get ruleOrder;

  @BuiltValueField(wireName: r'assignToTeam')
  SupportTeam? get assignToTeam;

  @BuiltValueField(wireName: r'assignToUser')
  User? get assignToUser;

  AssignmentRule._();

  factory AssignmentRule([void updates(AssignmentRuleBuilder b)]) = _$AssignmentRule;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(AssignmentRuleBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<AssignmentRule> get serializer => _$AssignmentRuleSerializer();
}

class _$AssignmentRuleSerializer implements PrimitiveSerializer<AssignmentRule> {
  @override
  final Iterable<Type> types = const [AssignmentRule, _$AssignmentRule];

  @override
  final String wireName = r'AssignmentRule';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    AssignmentRule object, {
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
    if (object.category != null) {
      yield r'category';
      yield serializers.serialize(
        object.category,
        specifiedType: const FullType(TicketCategory),
      );
    }
    if (object.priority != null) {
      yield r'priority';
      yield serializers.serialize(
        object.priority,
        specifiedType: const FullType(TicketPriority),
      );
    }
    if (object.assignToTeamID != null) {
      yield r'assignToTeamID';
      yield serializers.serialize(
        object.assignToTeamID,
        specifiedType: const FullType.nullable(int),
      );
    }
    if (object.assignToUserID != null) {
      yield r'assignToUserID';
      yield serializers.serialize(
        object.assignToUserID,
        specifiedType: const FullType.nullable(String),
      );
    }
    yield r'isActive';
    yield serializers.serialize(
      object.isActive,
      specifiedType: const FullType(bool),
    );
    yield r'ruleOrder';
    yield serializers.serialize(
      object.ruleOrder,
      specifiedType: const FullType(int),
    );
    if (object.assignToTeam != null) {
      yield r'assignToTeam';
      yield serializers.serialize(
        object.assignToTeam,
        specifiedType: const FullType(SupportTeam),
      );
    }
    if (object.assignToUser != null) {
      yield r'assignToUser';
      yield serializers.serialize(
        object.assignToUser,
        specifiedType: const FullType(User),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    AssignmentRule object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required AssignmentRuleBuilder result,
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
        case r'category':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(TicketCategory),
          ) as TicketCategory;
          result.category = valueDes;
          break;
        case r'priority':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(TicketPriority),
          ) as TicketPriority;
          result.priority = valueDes;
          break;
        case r'assignToTeamID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(int),
          ) as int?;
          if (valueDes == null) continue;
          result.assignToTeamID = valueDes;
          break;
        case r'assignToUserID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.assignToUserID = valueDes;
          break;
        case r'isActive':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.isActive = valueDes;
          break;
        case r'ruleOrder':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ruleOrder = valueDes;
          break;
        case r'assignToTeam':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(SupportTeam),
          ) as SupportTeam;
          result.assignToTeam.replace(valueDes);
          break;
        case r'assignToUser':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.assignToUser.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  AssignmentRule deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = AssignmentRuleBuilder();
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

