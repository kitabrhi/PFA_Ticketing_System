//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/ticket_status.dart';
import 'package:openapi/src/model/support_team.dart';
import 'package:built_collection/built_collection.dart';
import 'package:openapi/src/model/attachment.dart';
import 'package:openapi/src/model/ticket_priority.dart';
import 'package:openapi/src/model/user.dart';
import 'package:openapi/src/model/ticket_category.dart';
import 'package:openapi/src/model/ticket_history.dart';
import 'package:openapi/src/model/ticket_comment.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'ticket.g.dart';

/// Ticket
///
/// Properties:
/// * [ticketID] 
/// * [title] 
/// * [description] 
/// * [category] 
/// * [priority] 
/// * [status] 
/// * [createdByUserId] 
/// * [assignedToUserId] 
/// * [assignedToTeamID] 
/// * [createdDate] 
/// * [updatedDate] 
/// * [dueDate] 
/// * [resolutionDate] 
/// * [closedDate] 
/// * [source_] 
/// * [isEscalated] 
/// * [createdByUser] 
/// * [assignedToUser] 
/// * [assignedToTeam] 
/// * [ticketHistories] 
/// * [ticketComments] 
/// * [ticketAttachments] 
@BuiltValue()
abstract class Ticket implements Built<Ticket, TicketBuilder> {
  @BuiltValueField(wireName: r'ticketID')
  int? get ticketID;

  @BuiltValueField(wireName: r'title')
  String get title;

  @BuiltValueField(wireName: r'description')
  String get description;

  @BuiltValueField(wireName: r'category')
  TicketCategory get category;
  // enum categoryEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'priority')
  TicketPriority get priority;
  // enum priorityEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'status')
  TicketStatus get status;
  // enum statusEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'createdByUserId')
  String get createdByUserId;

  @BuiltValueField(wireName: r'assignedToUserId')
  String? get assignedToUserId;

  @BuiltValueField(wireName: r'assignedToTeamID')
  int? get assignedToTeamID;

  @BuiltValueField(wireName: r'createdDate')
  DateTime? get createdDate;

  @BuiltValueField(wireName: r'updatedDate')
  DateTime? get updatedDate;

  @BuiltValueField(wireName: r'dueDate')
  DateTime? get dueDate;

  @BuiltValueField(wireName: r'resolutionDate')
  DateTime? get resolutionDate;

  @BuiltValueField(wireName: r'closedDate')
  DateTime? get closedDate;

  @BuiltValueField(wireName: r'source')
  String get source_;

  @BuiltValueField(wireName: r'isEscalated')
  bool? get isEscalated;

  @BuiltValueField(wireName: r'createdByUser')
  User? get createdByUser;

  @BuiltValueField(wireName: r'assignedToUser')
  User? get assignedToUser;

  @BuiltValueField(wireName: r'assignedToTeam')
  SupportTeam? get assignedToTeam;

  @BuiltValueField(wireName: r'ticketHistories')
  BuiltList<TicketHistory>? get ticketHistories;

  @BuiltValueField(wireName: r'ticketComments')
  BuiltList<TicketComment>? get ticketComments;

  @BuiltValueField(wireName: r'ticketAttachments')
  BuiltList<Attachment>? get ticketAttachments;

  Ticket._();

  factory Ticket([void updates(TicketBuilder b)]) = _$Ticket;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(TicketBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<Ticket> get serializer => _$TicketSerializer();
}

class _$TicketSerializer implements PrimitiveSerializer<Ticket> {
  @override
  final Iterable<Type> types = const [Ticket, _$Ticket];

  @override
  final String wireName = r'Ticket';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    Ticket object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.ticketID != null) {
      yield r'ticketID';
      yield serializers.serialize(
        object.ticketID,
        specifiedType: const FullType(int),
      );
    }
    yield r'title';
    yield serializers.serialize(
      object.title,
      specifiedType: const FullType(String),
    );
    yield r'description';
    yield serializers.serialize(
      object.description,
      specifiedType: const FullType(String),
    );
    yield r'category';
    yield serializers.serialize(
      object.category,
      specifiedType: const FullType(TicketCategory),
    );
    yield r'priority';
    yield serializers.serialize(
      object.priority,
      specifiedType: const FullType(TicketPriority),
    );
    yield r'status';
    yield serializers.serialize(
      object.status,
      specifiedType: const FullType(TicketStatus),
    );
    yield r'createdByUserId';
    yield serializers.serialize(
      object.createdByUserId,
      specifiedType: const FullType(String),
    );
    if (object.assignedToUserId != null) {
      yield r'assignedToUserId';
      yield serializers.serialize(
        object.assignedToUserId,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.assignedToTeamID != null) {
      yield r'assignedToTeamID';
      yield serializers.serialize(
        object.assignedToTeamID,
        specifiedType: const FullType.nullable(int),
      );
    }
    if (object.createdDate != null) {
      yield r'createdDate';
      yield serializers.serialize(
        object.createdDate,
        specifiedType: const FullType(DateTime),
      );
    }
    if (object.updatedDate != null) {
      yield r'updatedDate';
      yield serializers.serialize(
        object.updatedDate,
        specifiedType: const FullType(DateTime),
      );
    }
    if (object.dueDate != null) {
      yield r'dueDate';
      yield serializers.serialize(
        object.dueDate,
        specifiedType: const FullType.nullable(DateTime),
      );
    }
    if (object.resolutionDate != null) {
      yield r'resolutionDate';
      yield serializers.serialize(
        object.resolutionDate,
        specifiedType: const FullType.nullable(DateTime),
      );
    }
    if (object.closedDate != null) {
      yield r'closedDate';
      yield serializers.serialize(
        object.closedDate,
        specifiedType: const FullType.nullable(DateTime),
      );
    }
    yield r'source';
    yield serializers.serialize(
      object.source_,
      specifiedType: const FullType(String),
    );
    if (object.isEscalated != null) {
      yield r'isEscalated';
      yield serializers.serialize(
        object.isEscalated,
        specifiedType: const FullType(bool),
      );
    }
    if (object.createdByUser != null) {
      yield r'createdByUser';
      yield serializers.serialize(
        object.createdByUser,
        specifiedType: const FullType(User),
      );
    }
    if (object.assignedToUser != null) {
      yield r'assignedToUser';
      yield serializers.serialize(
        object.assignedToUser,
        specifiedType: const FullType(User),
      );
    }
    if (object.assignedToTeam != null) {
      yield r'assignedToTeam';
      yield serializers.serialize(
        object.assignedToTeam,
        specifiedType: const FullType(SupportTeam),
      );
    }
    if (object.ticketHistories != null) {
      yield r'ticketHistories';
      yield serializers.serialize(
        object.ticketHistories,
        specifiedType: const FullType.nullable(BuiltList, [FullType(TicketHistory)]),
      );
    }
    if (object.ticketComments != null) {
      yield r'ticketComments';
      yield serializers.serialize(
        object.ticketComments,
        specifiedType: const FullType.nullable(BuiltList, [FullType(TicketComment)]),
      );
    }
    if (object.ticketAttachments != null) {
      yield r'ticketAttachments';
      yield serializers.serialize(
        object.ticketAttachments,
        specifiedType: const FullType.nullable(BuiltList, [FullType(Attachment)]),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    Ticket object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required TicketBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'ticketID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ticketID = valueDes;
          break;
        case r'title':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.title = valueDes;
          break;
        case r'description':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
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
        case r'status':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(TicketStatus),
          ) as TicketStatus;
          result.status = valueDes;
          break;
        case r'createdByUserId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.createdByUserId = valueDes;
          break;
        case r'assignedToUserId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.assignedToUserId = valueDes;
          break;
        case r'assignedToTeamID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(int),
          ) as int?;
          if (valueDes == null) continue;
          result.assignedToTeamID = valueDes;
          break;
        case r'createdDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.createdDate = valueDes;
          break;
        case r'updatedDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.updatedDate = valueDes;
          break;
        case r'dueDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(DateTime),
          ) as DateTime?;
          if (valueDes == null) continue;
          result.dueDate = valueDes;
          break;
        case r'resolutionDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(DateTime),
          ) as DateTime?;
          if (valueDes == null) continue;
          result.resolutionDate = valueDes;
          break;
        case r'closedDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(DateTime),
          ) as DateTime?;
          if (valueDes == null) continue;
          result.closedDate = valueDes;
          break;
        case r'source':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.source_ = valueDes;
          break;
        case r'isEscalated':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.isEscalated = valueDes;
          break;
        case r'createdByUser':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.createdByUser.replace(valueDes);
          break;
        case r'assignedToUser':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.assignedToUser.replace(valueDes);
          break;
        case r'assignedToTeam':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(SupportTeam),
          ) as SupportTeam;
          result.assignedToTeam.replace(valueDes);
          break;
        case r'ticketHistories':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(TicketHistory)]),
          ) as BuiltList<TicketHistory>?;
          if (valueDes == null) continue;
          result.ticketHistories.replace(valueDes);
          break;
        case r'ticketComments':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(TicketComment)]),
          ) as BuiltList<TicketComment>?;
          if (valueDes == null) continue;
          result.ticketComments.replace(valueDes);
          break;
        case r'ticketAttachments':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(Attachment)]),
          ) as BuiltList<Attachment>?;
          if (valueDes == null) continue;
          result.ticketAttachments.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  Ticket deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = TicketBuilder();
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

