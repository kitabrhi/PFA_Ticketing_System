import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:device_preview/device_preview.dart';
import 'package:openapi/src/screens/admin_dashboard.dart';
import 'package:openapi/src/screens/equipe_screen.dart';
import 'package:openapi/src/screens/home_screen.dart';
import 'package:openapi/src/screens/login_screen.dart';
import 'package:openapi/src/screens/register_screen.dart';
import 'package:openapi/src/screens/splash_screen.dart';
import 'package:openapi/src/screens/support_agent_screen.dart';
import 'package:openapi/src/screens/ticket_screen.dart';


void main() {
  runApp(
    DevicePreview(
      enabled: !kReleaseMode,
      builder: (context) => const MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      useInheritedMediaQuery: true,
      debugShowCheckedModeBanner: false,
      locale: DevicePreview.locale(context),
      builder: DevicePreview.appBuilder,
      title: 'QuantumDesk',
      theme: ThemeData(
        fontFamily: 'Arial',
        colorScheme: ColorScheme.fromSeed(seedColor: const Color(0xFF00A78E)),
        scaffoldBackgroundColor: const Color.fromARGB(255, 255, 255, 255),
      ),
      initialRoute: '/',
      routes: {
        '/': (context) => const SplashScreen(),
        '/home': (context) => const HomeScreen(),
        '/login': (context) => const LoginScreen(),
        '/register': (context) => const RegisterScreen(),
        '/dashboardadmin': (context) => const AdminDashboardScreen(),
        '/equipe': (context) => const EquipeScreen(),
        '/ticket' : (context) => const TicketScreen(),
        '/supportagent' : (context) => const SupportAgentScreen(),
      },
    );
  }
}
