//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/user.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'ticket_history.g.dart';

/// TicketHistory
///
/// Properties:
/// * [ticketHistoryID] 
/// * [ticketID] 
/// * [changedByUserId] 
/// * [fieldName] 
/// * [oldValue] 
/// * [newValue] 
/// * [changedDate] 
/// * [changedByUser] 
@BuiltValue()
abstract class TicketHistory implements Built<TicketHistory, TicketHistoryBuilder> {
  @BuiltValueField(wireName: r'ticketHistoryID')
  int? get ticketHistoryID;

  @BuiltValueField(wireName: r'ticketID')
  int get ticketID;

  @BuiltValueField(wireName: r'changedByUserId')
  String get changedByUserId;

  @BuiltValueField(wireName: r'fieldName')
  String get fieldName;

  @BuiltValueField(wireName: r'oldValue')
  String? get oldValue;

  @BuiltValueField(wireName: r'newValue')
  String? get newValue;

  @BuiltValueField(wireName: r'changedDate')
  DateTime? get changedDate;

  @BuiltValueField(wireName: r'changedByUser')
  User? get changedByUser;

  TicketHistory._();

  factory TicketHistory([void updates(TicketHistoryBuilder b)]) = _$TicketHistory;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(TicketHistoryBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<TicketHistory> get serializer => _$TicketHistorySerializer();
}

class _$TicketHistorySerializer implements PrimitiveSerializer<TicketHistory> {
  @override
  final Iterable<Type> types = const [TicketHistory, _$TicketHistory];

  @override
  final String wireName = r'TicketHistory';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    TicketHistory object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.ticketHistoryID != null) {
      yield r'ticketHistoryID';
      yield serializers.serialize(
        object.ticketHistoryID,
        specifiedType: const FullType(int),
      );
    }
    yield r'ticketID';
    yield serializers.serialize(
      object.ticketID,
      specifiedType: const FullType(int),
    );
    yield r'changedByUserId';
    yield serializers.serialize(
      object.changedByUserId,
      specifiedType: const FullType(String),
    );
    yield r'fieldName';
    yield serializers.serialize(
      object.fieldName,
      specifiedType: const FullType(String),
    );
    if (object.oldValue != null) {
      yield r'oldValue';
      yield serializers.serialize(
        object.oldValue,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.newValue != null) {
      yield r'newValue';
      yield serializers.serialize(
        object.newValue,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.changedDate != null) {
      yield r'changedDate';
      yield serializers.serialize(
        object.changedDate,
        specifiedType: const FullType(DateTime),
      );
    }
    if (object.changedByUser != null) {
      yield r'changedByUser';
      yield serializers.serialize(
        object.changedByUser,
        specifiedType: const FullType(User),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    TicketHistory object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required TicketHistoryBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'ticketHistoryID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ticketHistoryID = valueDes;
          break;
        case r'ticketID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ticketID = valueDes;
          break;
        case r'changedByUserId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.changedByUserId = valueDes;
          break;
        case r'fieldName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.fieldName = valueDes;
          break;
        case r'oldValue':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.oldValue = valueDes;
          break;
        case r'newValue':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.newValue = valueDes;
          break;
        case r'changedDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.changedDate = valueDes;
          break;
        case r'changedByUser':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.changedByUser.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  TicketHistory deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = TicketHistoryBuilder();
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

