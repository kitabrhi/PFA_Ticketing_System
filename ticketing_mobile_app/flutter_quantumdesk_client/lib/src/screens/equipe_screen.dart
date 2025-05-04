import 'package:flutter/material.dart';
import 'add_team_form_dialog.dart';

class EquipeScreen extends StatefulWidget {
  const EquipeScreen({super.key});

  @override
  State<EquipeScreen> createState() => _EquipeScreenState();
}

class _EquipeScreenState extends State<EquipeScreen> {
  final List<Map<String, String>> equipes = [];

  void _openCenteredForm() {
    showDialog(
      context: context,
      builder: (context) => const Center(child: AddTeamFormDialog()),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Équipes'),
        actions: [
          IconButton(
            icon: const Icon(Icons.add),
            onPressed: _openCenteredForm,
          ),
        ],
        backgroundColor: Colors.white,
        foregroundColor: Colors.black,
        elevation: 1,
      ),
      body: equipes.isEmpty
          ? const Center(child: Text('Aucune équipe ajoutée.'))
          : ListView.builder(
              itemCount: equipes.length,
              itemBuilder: (context, index) {
                final equipe = equipes[index];
                return Card(
                  margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
                  shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
                  elevation: 4,
                  child: ListTile(
                    title: Text(equipe['name'] ?? ''),
                    subtitle: Text(equipe['description'] ?? ''),
                  ),
                );
              },
            ),
    );
  }
}
