import 'package:openapi/src/model/ticket.dart';

void main() {
  final ticket = Ticket((b) => b
    ..title = 'Bug'
    ..description = 'Un bug critique'
    
  );

  print(ticket);
}
