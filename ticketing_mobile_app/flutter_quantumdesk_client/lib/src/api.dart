//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';
import 'package:openapi/src/serializers.dart';
import 'package:openapi/src/auth/api_key_auth.dart';
import 'package:openapi/src/auth/basic_auth.dart';
import 'package:openapi/src/auth/bearer_auth.dart';
import 'package:openapi/src/auth/oauth.dart';
import 'package:openapi/src/api/admin_api_api.dart';
import 'package:openapi/src/api/assignment_rules_api_api.dart';
import 'package:openapi/src/api/escalation_rules_api_api.dart';
import 'package:openapi/src/api/notifications_api_api.dart';
import 'package:openapi/src/api/support_teams_api_api.dart';
import 'package:openapi/src/api/team_members_api_api.dart';
import 'package:openapi/src/api/ticket_content_api_api.dart';
import 'package:openapi/src/api/tickets_api_api.dart';
import 'package:openapi/src/api/users_api_api.dart';

class Openapi {
  static const String basePath = r'http://localhost';

  final Dio dio;
  final Serializers serializers;

  Openapi({
    Dio? dio,
    Serializers? serializers,
    String? basePathOverride,
    List<Interceptor>? interceptors,
  })  : this.serializers = serializers ?? standardSerializers,
        this.dio = dio ??
            Dio(BaseOptions(
              baseUrl: basePathOverride ?? basePath,
              connectTimeout: const Duration(milliseconds: 5000),
              receiveTimeout: const Duration(milliseconds: 3000),
            )) {
    if (interceptors == null) {
      this.dio.interceptors.addAll([
        OAuthInterceptor(),
        BasicAuthInterceptor(),
        BearerAuthInterceptor(),
        ApiKeyAuthInterceptor(),
      ]);
    } else {
      this.dio.interceptors.addAll(interceptors);
    }
  }

  void setOAuthToken(String name, String token) {
    if (this.dio.interceptors.any((i) => i is OAuthInterceptor)) {
      (this.dio.interceptors.firstWhere((i) => i is OAuthInterceptor) as OAuthInterceptor).tokens[name] = token;
    }
  }

  void setBearerAuth(String name, String token) {
    if (this.dio.interceptors.any((i) => i is BearerAuthInterceptor)) {
      (this.dio.interceptors.firstWhere((i) => i is BearerAuthInterceptor) as BearerAuthInterceptor).tokens[name] = token;
    }
  }

  void setBasicAuth(String name, String username, String password) {
    if (this.dio.interceptors.any((i) => i is BasicAuthInterceptor)) {
      (this.dio.interceptors.firstWhere((i) => i is BasicAuthInterceptor) as BasicAuthInterceptor).authInfo[name] = BasicAuthInfo(username, password);
    }
  }

  void setApiKey(String name, String apiKey) {
    if (this.dio.interceptors.any((i) => i is ApiKeyAuthInterceptor)) {
      (this.dio.interceptors.firstWhere((element) => element is ApiKeyAuthInterceptor) as ApiKeyAuthInterceptor).apiKeys[name] = apiKey;
    }
  }

  /// Get AdminApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  AdminApiApi getAdminApiApi() {
    return AdminApiApi(dio, serializers);
  }

  /// Get AssignmentRulesApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  AssignmentRulesApiApi getAssignmentRulesApiApi() {
    return AssignmentRulesApiApi(dio, serializers);
  }

  /// Get EscalationRulesApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  EscalationRulesApiApi getEscalationRulesApiApi() {
    return EscalationRulesApiApi(dio, serializers);
  }

  /// Get NotificationsApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  NotificationsApiApi getNotificationsApiApi() {
    return NotificationsApiApi(dio, serializers);
  }

  /// Get SupportTeamsApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  SupportTeamsApiApi getSupportTeamsApiApi() {
    return SupportTeamsApiApi(dio, serializers);
  }

  /// Get TeamMembersApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  TeamMembersApiApi getTeamMembersApiApi() {
    return TeamMembersApiApi(dio, serializers);
  }

  /// Get TicketContentApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  TicketContentApiApi getTicketContentApiApi() {
    return TicketContentApiApi(dio, serializers);
  }

  /// Get TicketsApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  TicketsApiApi getTicketsApiApi() {
    return TicketsApiApi(dio, serializers);
  }

  /// Get UsersApiApi instance, base route and serializer can be overridden by a given but be careful,
  /// by doing that all interceptors will not be executed
  UsersApiApi getUsersApiApi() {
    return UsersApiApi(dio, serializers);
  }
}
