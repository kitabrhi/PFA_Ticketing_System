
import 'package:flutter/material.dart';
import 'package:device_preview/device_preview.dart';
import 'package:openapi/src/screens/splash_screen.dart';
import 'src/screens/onboarding_screen.dart';

void main() {
  runApp(
    DevicePreview(
      enabled: true,
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
        scaffoldBackgroundColor: Colors.grey.shade100,
      ),
      initialRoute: '/',
      routes: {
        '/': (context) => const SplashScreen(),
        '/home': (context) => const OnboardingScreen(),
      },
    );
  }
}
