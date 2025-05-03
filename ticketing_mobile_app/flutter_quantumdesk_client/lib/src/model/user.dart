//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/support_team.dart';
import 'package:built_collection/built_collection.dart';
import 'package:openapi/src/model/knowledge_base_article.dart';
import 'package:openapi/src/model/attachment.dart';
import 'package:openapi/src/model/notification.dart';
import 'package:openapi/src/model/team_member.dart';
import 'package:openapi/src/model/ticket.dart';
import 'package:openapi/src/model/ticket_history.dart';
import 'package:openapi/src/model/ticket_comment.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'user.g.dart';

/// User
///
/// Properties:
/// * [id] 
/// * [userName] 
/// * [normalizedUserName] 
/// * [email] 
/// * [normalizedEmail] 
/// * [emailConfirmed] 
/// * [passwordHash] 
/// * [securityStamp] 
/// * [concurrencyStamp] 
/// * [phoneNumber] 
/// * [phoneNumberConfirmed] 
/// * [twoFactorEnabled] 
/// * [lockoutEnd] 
/// * [lockoutEnabled] 
/// * [accessFailedCount] 
/// * [firstName] 
/// * [lastName] 
/// * [createdDate] 
/// * [lastLoginDate] 
/// * [isActive] 
/// * [createdTickets] 
/// * [assignedTickets] 
/// * [managedTeams] 
/// * [teamMemberships] 
/// * [comments] 
/// * [attachments] 
/// * [ticketChanges] 
/// * [articles] 
/// * [notifications] 
@BuiltValue()
abstract class User implements Built<User, UserBuilder> {
  @BuiltValueField(wireName: r'id')
  String? get id;

  @BuiltValueField(wireName: r'userName')
  String? get userName;

  @BuiltValueField(wireName: r'normalizedUserName')
  String? get normalizedUserName;

  @BuiltValueField(wireName: r'email')
  String? get email;

  @BuiltValueField(wireName: r'normalizedEmail')
  String? get normalizedEmail;

  @BuiltValueField(wireName: r'emailConfirmed')
  bool? get emailConfirmed;

  @BuiltValueField(wireName: r'passwordHash')
  String? get passwordHash;

  @BuiltValueField(wireName: r'securityStamp')
  String? get securityStamp;

  @BuiltValueField(wireName: r'concurrencyStamp')
  String? get concurrencyStamp;

  @BuiltValueField(wireName: r'phoneNumber')
  String? get phoneNumber;

  @BuiltValueField(wireName: r'phoneNumberConfirmed')
  bool? get phoneNumberConfirmed;

  @BuiltValueField(wireName: r'twoFactorEnabled')
  bool? get twoFactorEnabled;

  @BuiltValueField(wireName: r'lockoutEnd')
  DateTime? get lockoutEnd;

  @BuiltValueField(wireName: r'lockoutEnabled')
  bool? get lockoutEnabled;

  @BuiltValueField(wireName: r'accessFailedCount')
  int? get accessFailedCount;

  @BuiltValueField(wireName: r'firstName')
  String? get firstName;

  @BuiltValueField(wireName: r'lastName')
  String? get lastName;

  @BuiltValueField(wireName: r'createdDate')
  DateTime get createdDate;

  @BuiltValueField(wireName: r'lastLoginDate')
  DateTime? get lastLoginDate;

  @BuiltValueField(wireName: r'isActive')
  bool get isActive;

  @BuiltValueField(wireName: r'createdTickets')
  BuiltList<Ticket>? get createdTickets;

  @BuiltValueField(wireName: r'assignedTickets')
  BuiltList<Ticket>? get assignedTickets;

  @BuiltValueField(wireName: r'managedTeams')
  BuiltList<SupportTeam>? get managedTeams;

  @BuiltValueField(wireName: r'teamMemberships')
  BuiltList<TeamMember>? get teamMemberships;

  @BuiltValueField(wireName: r'comments')
  BuiltList<TicketComment>? get comments;

  @BuiltValueField(wireName: r'attachments')
  BuiltList<Attachment>? get attachments;

  @BuiltValueField(wireName: r'ticketChanges')
  BuiltList<TicketHistory>? get ticketChanges;

  @BuiltValueField(wireName: r'articles')
  BuiltList<KnowledgeBaseArticle>? get articles;

  @BuiltValueField(wireName: r'notifications')
  BuiltList<Notification>? get notifications;

  User._();

  factory User([void updates(UserBuilder b)]) = _$User;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(UserBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<User> get serializer => _$UserSerializer();
}

class _$UserSerializer implements PrimitiveSerializer<User> {
  @override
  final Iterable<Type> types = const [User, _$User];

  @override
  final String wireName = r'User';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    User object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.id != null) {
      yield r'id';
      yield serializers.serialize(
        object.id,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.userName != null) {
      yield r'userName';
      yield serializers.serialize(
        object.userName,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.normalizedUserName != null) {
      yield r'normalizedUserName';
      yield serializers.serialize(
        object.normalizedUserName,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.email != null) {
      yield r'email';
      yield serializers.serialize(
        object.email,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.normalizedEmail != null) {
      yield r'normalizedEmail';
      yield serializers.serialize(
        object.normalizedEmail,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.emailConfirmed != null) {
      yield r'emailConfirmed';
      yield serializers.serialize(
        object.emailConfirmed,
        specifiedType: const FullType(bool),
      );
    }
    if (object.passwordHash != null) {
      yield r'passwordHash';
      yield serializers.serialize(
        object.passwordHash,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.securityStamp != null) {
      yield r'securityStamp';
      yield serializers.serialize(
        object.securityStamp,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.concurrencyStamp != null) {
      yield r'concurrencyStamp';
      yield serializers.serialize(
        object.concurrencyStamp,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.phoneNumber != null) {
      yield r'phoneNumber';
      yield serializers.serialize(
        object.phoneNumber,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.phoneNumberConfirmed != null) {
      yield r'phoneNumberConfirmed';
      yield serializers.serialize(
        object.phoneNumberConfirmed,
        specifiedType: const FullType(bool),
      );
    }
    if (object.twoFactorEnabled != null) {
      yield r'twoFactorEnabled';
      yield serializers.serialize(
        object.twoFactorEnabled,
        specifiedType: const FullType(bool),
      );
    }
    if (object.lockoutEnd != null) {
      yield r'lockoutEnd';
      yield serializers.serialize(
        object.lockoutEnd,
        specifiedType: const FullType.nullable(DateTime),
      );
    }
    if (object.lockoutEnabled != null) {
      yield r'lockoutEnabled';
      yield serializers.serialize(
        object.lockoutEnabled,
        specifiedType: const FullType(bool),
      );
    }
    if (object.accessFailedCount != null) {
      yield r'accessFailedCount';
      yield serializers.serialize(
        object.accessFailedCount,
        specifiedType: const FullType(int),
      );
    }
    if (object.firstName != null) {
      yield r'firstName';
      yield serializers.serialize(
        object.firstName,
        specifiedType: const FullType.nullable(String),
      );
    }
    if (object.lastName != null) {
      yield r'lastName';
      yield serializers.serialize(
        object.lastName,
        specifiedType: const FullType.nullable(String),
      );
    }
    yield r'createdDate';
    yield serializers.serialize(
      object.createdDate,
      specifiedType: const FullType(DateTime),
    );
    if (object.lastLoginDate != null) {
      yield r'lastLoginDate';
      yield serializers.serialize(
        object.lastLoginDate,
        specifiedType: const FullType.nullable(DateTime),
      );
    }
    yield r'isActive';
    yield serializers.serialize(
      object.isActive,
      specifiedType: const FullType(bool),
    );
    if (object.createdTickets != null) {
      yield r'createdTickets';
      yield serializers.serialize(
        object.createdTickets,
        specifiedType: const FullType.nullable(BuiltList, [FullType(Ticket)]),
      );
    }
    if (object.assignedTickets != null) {
      yield r'assignedTickets';
      yield serializers.serialize(
        object.assignedTickets,
        specifiedType: const FullType.nullable(BuiltList, [FullType(Ticket)]),
      );
    }
    if (object.managedTeams != null) {
      yield r'managedTeams';
      yield serializers.serialize(
        object.managedTeams,
        specifiedType: const FullType.nullable(BuiltList, [FullType(SupportTeam)]),
      );
    }
    if (object.teamMemberships != null) {
      yield r'teamMemberships';
      yield serializers.serialize(
        object.teamMemberships,
        specifiedType: const FullType.nullable(BuiltList, [FullType(TeamMember)]),
      );
    }
    if (object.comments != null) {
      yield r'comments';
      yield serializers.serialize(
        object.comments,
        specifiedType: const FullType.nullable(BuiltList, [FullType(TicketComment)]),
      );
    }
    if (object.attachments != null) {
      yield r'attachments';
      yield serializers.serialize(
        object.attachments,
        specifiedType: const FullType.nullable(BuiltList, [FullType(Attachment)]),
      );
    }
    if (object.ticketChanges != null) {
      yield r'ticketChanges';
      yield serializers.serialize(
        object.ticketChanges,
        specifiedType: const FullType.nullable(BuiltList, [FullType(TicketHistory)]),
      );
    }
    if (object.articles != null) {
      yield r'articles';
      yield serializers.serialize(
        object.articles,
        specifiedType: const FullType.nullable(BuiltList, [FullType(KnowledgeBaseArticle)]),
      );
    }
    if (object.notifications != null) {
      yield r'notifications';
      yield serializers.serialize(
        object.notifications,
        specifiedType: const FullType.nullable(BuiltList, [FullType(Notification)]),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    User object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required UserBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'id':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.id = valueDes;
          break;
        case r'userName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.userName = valueDes;
          break;
        case r'normalizedUserName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.normalizedUserName = valueDes;
          break;
        case r'email':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.email = valueDes;
          break;
        case r'normalizedEmail':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.normalizedEmail = valueDes;
          break;
        case r'emailConfirmed':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.emailConfirmed = valueDes;
          break;
        case r'passwordHash':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.passwordHash = valueDes;
          break;
        case r'securityStamp':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.securityStamp = valueDes;
          break;
        case r'concurrencyStamp':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.concurrencyStamp = valueDes;
          break;
        case r'phoneNumber':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.phoneNumber = valueDes;
          break;
        case r'phoneNumberConfirmed':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.phoneNumberConfirmed = valueDes;
          break;
        case r'twoFactorEnabled':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.twoFactorEnabled = valueDes;
          break;
        case r'lockoutEnd':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(DateTime),
          ) as DateTime?;
          if (valueDes == null) continue;
          result.lockoutEnd = valueDes;
          break;
        case r'lockoutEnabled':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.lockoutEnabled = valueDes;
          break;
        case r'accessFailedCount':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.accessFailedCount = valueDes;
          break;
        case r'firstName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.firstName = valueDes;
          break;
        case r'lastName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.lastName = valueDes;
          break;
        case r'createdDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.createdDate = valueDes;
          break;
        case r'lastLoginDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(DateTime),
          ) as DateTime?;
          if (valueDes == null) continue;
          result.lastLoginDate = valueDes;
          break;
        case r'isActive':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.isActive = valueDes;
          break;
        case r'createdTickets':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(Ticket)]),
          ) as BuiltList<Ticket>?;
          if (valueDes == null) continue;
          result.createdTickets.replace(valueDes);
          break;
        case r'assignedTickets':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(Ticket)]),
          ) as BuiltList<Ticket>?;
          if (valueDes == null) continue;
          result.assignedTickets.replace(valueDes);
          break;
        case r'managedTeams':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(SupportTeam)]),
          ) as BuiltList<SupportTeam>?;
          if (valueDes == null) continue;
          result.managedTeams.replace(valueDes);
          break;
        case r'teamMemberships':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(TeamMember)]),
          ) as BuiltList<TeamMember>?;
          if (valueDes == null) continue;
          result.teamMemberships.replace(valueDes);
          break;
        case r'comments':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(TicketComment)]),
          ) as BuiltList<TicketComment>?;
          if (valueDes == null) continue;
          result.comments.replace(valueDes);
          break;
        case r'attachments':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(Attachment)]),
          ) as BuiltList<Attachment>?;
          if (valueDes == null) continue;
          result.attachments.replace(valueDes);
          break;
        case r'ticketChanges':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(TicketHistory)]),
          ) as BuiltList<TicketHistory>?;
          if (valueDes == null) continue;
          result.ticketChanges.replace(valueDes);
          break;
        case r'articles':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(KnowledgeBaseArticle)]),
          ) as BuiltList<KnowledgeBaseArticle>?;
          if (valueDes == null) continue;
          result.articles.replace(valueDes);
          break;
        case r'notifications':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(Notification)]),
          ) as BuiltList<Notification>?;
          if (valueDes == null) continue;
          result.notifications.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  User deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = UserBuilder();
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

