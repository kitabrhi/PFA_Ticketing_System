// =============================
// 📄 Fichier : add_team_form_dialog.dart
// =============================

import 'package:flutter/material.dart';

class AddTeamFormDialog extends StatefulWidget {
  const AddTeamFormDialog({super.key});

  @override
  State<AddTeamFormDialog> createState() => _AddTeamFormDialogState();
}

class _AddTeamFormDialogState extends State<AddTeamFormDialog> {
  final _formKey = GlobalKey<FormState>();
  String teamName = '';
  String description = '';
  List<String> selectedManagers = [];
  List<String> selectedMembers = [];
  List<String> selectedTickets = [];

  final allManagers = ['Alice', 'Bob', 'Charlie'];
  final allMembers = ['David', 'Eva', 'Frank'];
  final allTickets = ['TCK-101', 'TCK-102', 'TCK-103'];

  @override
  Widget build(BuildContext context) {
    return Dialog(
      insetPadding: const EdgeInsets.all(20),
      backgroundColor: Colors.white,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(25)),
      child: Padding(
        padding: const EdgeInsets.all(24),
        child: SingleChildScrollView(
          child: Form(
            key: _formKey,
            child: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const Center(
                  child: Text(
                    'Créer une Équipe',
                    style: TextStyle(fontSize: 22, fontWeight: FontWeight.bold),
                  ),
                ),
                const SizedBox(height: 20),
                TextFormField(
                  decoration: const InputDecoration(
                    labelText: 'Nom de l’équipe',
                    border: OutlineInputBorder(),
                  ),
                  validator: (value) => value!.isEmpty ? 'Champ requis' : null,
                  onChanged: (val) => teamName = val,
                ),
                const SizedBox(height: 14),
                TextFormField(
                  decoration: const InputDecoration(
                    labelText: 'Description',
                    border: OutlineInputBorder(),
                  ),
                  onChanged: (val) => description = val,
                ),
                const SizedBox(height: 20),
                buildMultiSelectSection('Managers', allManagers, selectedManagers),
                buildMultiSelectSection('Membres de l’équipe', allMembers, selectedMembers),
                buildMultiSelectSection('Tickets assignés', allTickets, selectedTickets),
                const SizedBox(height: 24),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: () {
                      if (_formKey.currentState!.validate()) {
                        Navigator.pop(context);
                        ScaffoldMessenger.of(context).showSnackBar(
                          const SnackBar(content: Text('Équipe ajoutée !')),
                        );
                      }
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.black,
                      padding: const EdgeInsets.symmetric(vertical: 14),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(12),
                      ),
                    ),
                    child: const Text('Ajouter', style: TextStyle(color: Colors.white)),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget buildMultiSelectSection(String title, List<String> options, List<String> selectedList) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(title, style: const TextStyle(fontWeight: FontWeight.w600)),
        const SizedBox(height: 8),
        Wrap(
          spacing: 8,
          children: options.map((item) {
            final isSelected = selectedList.contains(item);
            return FilterChip(
              label: Text(item),
              selected: isSelected,
              onSelected: (selected) {
                setState(() {
                  selected ? selectedList.add(item) : selectedList.remove(item);
                });
              },
              selectedColor: Colors.teal.shade200,
            );
          }).toList(),
        ),
        const SizedBox(height: 16),
      ],
    );
  }
}
