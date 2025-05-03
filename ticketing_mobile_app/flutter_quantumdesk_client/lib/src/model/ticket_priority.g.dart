// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket_priority.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

const TicketPriority _$number0 = const TicketPriority._('number0');
const TicketPriority _$number1 = const TicketPriority._('number1');
const TicketPriority _$number2 = const TicketPriority._('number2');
const TicketPriority _$number3 = const TicketPriority._('number3');

TicketPriority _$valueOf(String name) {
  switch (name) {
    case 'number0':
      return _$number0;
    case 'number1':
      return _$number1;
    case 'number2':
      return _$number2;
    case 'number3':
      return _$number3;
    default:
      throw new ArgumentError(name);
  }
}

final BuiltSet<TicketPriority> _$values =
    new BuiltSet<TicketPriority>(const <TicketPriority>[
  _$number0,
  _$number1,
  _$number2,
  _$number3,
]);

class _$TicketPriorityMeta {
  const _$TicketPriorityMeta();
  TicketPriority get number0 => _$number0;
  TicketPriority get number1 => _$number1;
  TicketPriority get number2 => _$number2;
  TicketPriority get number3 => _$number3;
  TicketPriority valueOf(String name) => _$valueOf(name);
  BuiltSet<TicketPriority> get values => _$values;
}

abstract class _$TicketPriorityMixin {
  // ignore: non_constant_identifier_names
  _$TicketPriorityMeta get TicketPriority => const _$TicketPriorityMeta();
}

Serializer<TicketPriority> _$ticketPrioritySerializer =
    new _$TicketPrioritySerializer();

class _$TicketPrioritySerializer
    implements PrimitiveSerializer<TicketPriority> {
  static const Map<String, Object> _toWire = const <String, Object>{
    'number0': 0,
    'number1': 1,
    'number2': 2,
    'number3': 3,
  };
  static const Map<Object, String> _fromWire = const <Object, String>{
    0: 'number0',
    1: 'number1',
    2: 'number2',
    3: 'number3',
  };

  @override
  final Iterable<Type> types = const <Type>[TicketPriority];
  @override
  final String wireName = 'TicketPriority';

  @override
  Object serialize(Serializers serializers, TicketPriority object,
          {FullType specifiedType = FullType.unspecified}) =>
      _toWire[object.name] ?? object.name;

  @override
  TicketPriority deserialize(Serializers serializers, Object serialized,
          {FullType specifiedType = FullType.unspecified}) =>
      TicketPriority.valueOf(
          _fromWire[serialized] ?? (serialized is String ? serialized : ''));
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
