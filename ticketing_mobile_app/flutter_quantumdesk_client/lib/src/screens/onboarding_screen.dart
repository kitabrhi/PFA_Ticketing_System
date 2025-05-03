import 'package:flutter/material.dart';
import '../constants/colors.dart';

class OnboardingScreen extends StatefulWidget {
  const OnboardingScreen({super.key});

  @override
  State<OnboardingScreen> createState() => _OnboardingScreenState();
}

class _OnboardingScreenState extends State<OnboardingScreen> {
  final PageController _pageController = PageController();
  int _currentPage = 0;

  final List<Map<String, String>> onboardingData = [
    {
      'image': 'assets/images/intro1.png',
      'title': 'Welcome to QuantumDesk',
      'subtitle':
          'Your complete ticketing & issue tracking system.\n\nSimplify your support process, track progress, and deliver an outstanding customer experience with ease.',
    },
    {
      'image': 'assets/images/intro2.png',
      'title': 'Efficient Ticket Management',
      'subtitle':
          'Create, prioritize, assign, and monitor support tickets directly from your mobile device. Stay on top of everything, even on the move.',
    },
    {
      'image': 'assets/images/intro3.png',
      'title': 'Real-Time Notifications',
      'subtitle':
          'Get instantly notified when a ticket is assigned, escalated, or resolved. Never miss an important update again.',
    },
  ];

  @override
  Widget build(BuildContext context) {
    final isLastPage = _currentPage == onboardingData.length - 1;
    final size = MediaQuery.of(context).size;

    return Scaffold(
      body: SafeArea(
        child: PageView.builder(
          controller: _pageController,
          itemCount: onboardingData.length,
          onPageChanged: (index) {
            setState(() {
              _currentPage = index;
            });
          },
          itemBuilder: (context, index) {
            final data = onboardingData[index];

            return Column(
              children: [
                const SizedBox(height: 40),

                // 🖼 Image
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 24),
                  child: Image.asset(
                    data['image']!,
                    height: size.height * 0.35,
                    fit: BoxFit.contain,
                  ),
                ),

                const SizedBox(height: 20),

                // Bloc inférieur
                Expanded(
                  child: Container(
                    width: double.infinity,
                    padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 28),
                    decoration: BoxDecoration(
                      color: quantumSecondary,
                      borderRadius: const BorderRadius.only(
                        topLeft: Radius.circular(40),
                        topRight: Radius.circular(40),
                      ),
                    ),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          data['title']!,
                          style: const TextStyle(
                            fontSize: 24,
                            fontWeight: FontWeight.w700,
                            color: Colors.black,
                          ),
                        ),
                        const SizedBox(height: 16),
                        Text(
                          data['subtitle']!,
                          style: const TextStyle(
                            fontSize: 16,
                            height: 1.6,
                            color: Colors.black87,
                          ),
                        ),
                        const Spacer(),

                        // ⬤ Dots + CTA
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Row(
                              children: List.generate(
                                onboardingData.length,
                                (dotIndex) => AnimatedContainer(
                                  duration: const Duration(milliseconds: 200),
                                  margin: const EdgeInsets.symmetric(horizontal: 4),
                                  width: _currentPage == dotIndex ? 12 : 8,
                                  height: _currentPage == dotIndex ? 12 : 8,
                                  decoration: BoxDecoration(
                                    shape: BoxShape.circle,
                                    color: _currentPage == dotIndex
                                        ? Colors.white
                                        : Colors.black26,
                                  ),
                                ),
                              ),
                            ),
                            ElevatedButton.icon(
                              onPressed: () {
                                if (!isLastPage) {
                                  _pageController.nextPage(
                                    duration: const Duration(milliseconds: 300),
                                    curve: Curves.easeInOut,
                                  );
                                } else {
                                  Navigator.pushReplacementNamed(context, '/home');
                                }
                              },
                              icon: Icon(isLastPage ? Icons.check : Icons.arrow_forward),
                              label: Text(isLastPage ? "Start Now" : "Next"),
                              style: ElevatedButton.styleFrom(
                                foregroundColor: Colors.black,
                                backgroundColor: Colors.white,
                                padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 12),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(30),
                                ),
                                textStyle: const TextStyle(
                                  fontWeight: FontWeight.w600,
                                  fontSize: 15,
                                ),
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            );
          },
        ),
      ),
    );
  }
}
