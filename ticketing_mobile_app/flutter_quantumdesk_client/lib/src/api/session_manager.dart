import 'package:http/http.dart' as http;

class SessionManager {
  static final http.Client client = http.Client();
  static Map<String, String> headers = {};

  static Future<http.Response> post(Uri url, {Map<String, String>? body}) async {
    final response = await client.post(url, body: body, headers: headers);
    if (response.headers.containsKey('set-cookie')) {
      headers['cookie'] = response.headers['set-cookie']!;
    }
    return response;
  }

  static Future<http.Response> get(Uri url) async {
    return await client.get(url, headers: headers);
  }
}
