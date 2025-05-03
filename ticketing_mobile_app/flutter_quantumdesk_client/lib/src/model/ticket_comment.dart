//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/user.dart';
import 'package:openapi/src/model/ticket.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'ticket_comment.g.dart';

/// TicketComment
///
/// Properties:
/// * [commentID] 
/// * [ticketID] 
/// * [userId] 
/// * [commentText] 
/// * [isInternal] 
/// * [createdDate] 
/// * [ticket] 
/// * [user] 
@BuiltValue()
abstract class TicketComment implements Built<TicketComment, TicketCommentBuilder> {
  @BuiltValueField(wireName: r'commentID')
  int? get commentID;

  @BuiltValueField(wireName: r'ticketID')
  int get ticketID;

  @BuiltValueField(wireName: r'userId')
  String get userId;

  @BuiltValueField(wireName: r'commentText')
  String get commentText;

  @BuiltValueField(wireName: r'isInternal')
  bool? get isInternal;

  @BuiltValueField(wireName: r'createdDate')
  DateTime? get createdDate;

  @BuiltValueField(wireName: r'ticket')
  Ticket? get ticket;

  @BuiltValueField(wireName: r'user')
  User? get user;

  TicketComment._();

  factory TicketComment([void updates(TicketCommentBuilder b)]) = _$TicketComment;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(TicketCommentBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<TicketComment> get serializer => _$TicketCommentSerializer();
}

class _$TicketCommentSerializer implements PrimitiveSerializer<TicketComment> {
  @override
  final Iterable<Type> types = const [TicketComment, _$TicketComment];

  @override
  final String wireName = r'TicketComment';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    TicketComment object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.commentID != null) {
      yield r'commentID';
      yield serializers.serialize(
        object.commentID,
        specifiedType: const FullType(int),
      );
    }
    yield r'ticketID';
    yield serializers.serialize(
      object.ticketID,
      specifiedType: const FullType(int),
    );
    yield r'userId';
    yield serializers.serialize(
      object.userId,
      specifiedType: const FullType(String),
    );
    yield r'commentText';
    yield serializers.serialize(
      object.commentText,
      specifiedType: const FullType(String),
    );
    if (object.isInternal != null) {
      yield r'isInternal';
      yield serializers.serialize(
        object.isInternal,
        specifiedType: const FullType(bool),
      );
    }
    if (object.createdDate != null) {
      yield r'createdDate';
      yield serializers.serialize(
        object.createdDate,
        specifiedType: const FullType(DateTime),
      );
    }
    if (object.ticket != null) {
      yield r'ticket';
      yield serializers.serialize(
        object.ticket,
        specifiedType: const FullType(Ticket),
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
    TicketComment object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required TicketCommentBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'commentID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.commentID = valueDes;
          break;
        case r'ticketID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ticketID = valueDes;
          break;
        case r'userId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.userId = valueDes;
          break;
        case r'commentText':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.commentText = valueDes;
          break;
        case r'isInternal':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.isInternal = valueDes;
          break;
        case r'createdDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.createdDate = valueDes;
          break;
        case r'ticket':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(Ticket),
          ) as Ticket;
          result.ticket.replace(valueDes);
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
  TicketComment deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = TicketCommentBuilder();
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

