//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_import

import 'package:one_of_serializer/any_of_serializer.dart';
import 'package:one_of_serializer/one_of_serializer.dart';
import 'package:built_collection/built_collection.dart';
import 'package:built_value/json_object.dart';
import 'package:built_value/serializer.dart';
import 'package:built_value/standard_json_plugin.dart';
import 'package:built_value/iso_8601_date_time_serializer.dart';
import 'package:openapi/src/date_serializer.dart';
import 'package:openapi/src/model/date.dart';

import 'package:openapi/src/model/assignment_rule.dart';
import 'package:openapi/src/model/attachment.dart';
import 'package:openapi/src/model/create_user_model.dart';
import 'package:openapi/src/model/edit_user_model.dart';
import 'package:openapi/src/model/escalation_rule.dart';
import 'package:openapi/src/model/knowledge_base_article.dart';
import 'package:openapi/src/model/notification.dart';
import 'package:openapi/src/model/support_team.dart';
import 'package:openapi/src/model/team_member.dart';
import 'package:openapi/src/model/ticket.dart';
import 'package:openapi/src/model/ticket_category.dart';
import 'package:openapi/src/model/ticket_comment.dart';
import 'package:openapi/src/model/ticket_history.dart';
import 'package:openapi/src/model/ticket_priority.dart';
import 'package:openapi/src/model/ticket_status.dart';
import 'package:openapi/src/model/user.dart';

part 'serializers.g.dart';

@SerializersFor([
  AssignmentRule,
  Attachment,
  CreateUserModel,
  EditUserModel,
  EscalationRule,
  KnowledgeBaseArticle,
  Notification,
  SupportTeam,
  TeamMember,
  Ticket,
  TicketCategory,
  TicketComment,
  TicketHistory,
  TicketPriority,
  TicketStatus,
  User,
])
Serializers serializers = (_$serializers.toBuilder()
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(EscalationRule)]),
        () => ListBuilder<EscalationRule>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(User)]),
        () => ListBuilder<User>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Notification)]),
        () => ListBuilder<Notification>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(TeamMember)]),
        () => ListBuilder<TeamMember>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Attachment)]),
        () => ListBuilder<Attachment>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(TicketHistory)]),
        () => ListBuilder<TicketHistory>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(SupportTeam)]),
        () => ListBuilder<SupportTeam>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(TicketComment)]),
        () => ListBuilder<TicketComment>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(AssignmentRule)]),
        () => ListBuilder<AssignmentRule>(),
      )
      ..addBuilderFactory(
        const FullType(BuiltList, [FullType(Ticket)]),
        () => ListBuilder<Ticket>(),
      )
      ..add(const OneOfSerializer())
      ..add(const AnyOfSerializer())
      ..add(const DateSerializer())
      ..add(Iso8601DateTimeSerializer())
    ).build();

Serializers standardSerializers =
    (serializers.toBuilder()..addPlugin(StandardJsonPlugin())).build();
