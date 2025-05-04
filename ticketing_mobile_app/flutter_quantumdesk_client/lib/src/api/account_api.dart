import 'dart:convert';
import 'package:http/http.dart' as http;

class AccountApi {
  static Future<http.Response> login(String email, String password) {
    return http.post(
      Uri.parse('http://localhost:5021/api/account/login'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({"email": email, "password": password}),
    );
  }

  static Future<http.Response> register({
    required String firstName,
    required String lastName,
    required String email,
    required String password,
  }) {
    return http.post(
      Uri.parse('http://localhost:5021/api/account/register'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        "firstName": firstName,
        "lastName": lastName,
        "email": email,
        "password": password,
      }),
    );
  }
}
