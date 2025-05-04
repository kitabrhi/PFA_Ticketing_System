// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket_category.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

const TicketCategory _$number0 = const TicketCategory._('number0');
const TicketCategory _$number1 = const TicketCategory._('number1');
const TicketCategory _$number2 = const TicketCategory._('number2');
const TicketCategory _$number3 = const TicketCategory._('number3');

TicketCategory _$valueOf(String name) {
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

final BuiltSet<TicketCategory> _$values =
    new BuiltSet<TicketCategory>(const <TicketCategory>[
  _$number0,
  _$number1,
  _$number2,
  _$number3,
]);

class _$TicketCategoryMeta {
  const _$TicketCategoryMeta();
  TicketCategory get number0 => _$number0;
  TicketCategory get number1 => _$number1;
  TicketCategory get number2 => _$number2;
  TicketCategory get number3 => _$number3;
  TicketCategory valueOf(String name) => _$valueOf(name);
  BuiltSet<TicketCategory> get values => _$values;
}

abstract class _$TicketCategoryMixin {
  // ignore: non_constant_identifier_names
  _$TicketCategoryMeta get TicketCategory => const _$TicketCategoryMeta();
}

Serializer<TicketCategory> _$ticketCategorySerializer =
    new _$TicketCategorySerializer();

class _$TicketCategorySerializer
    implements PrimitiveSerializer<TicketCategory> {
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
  final Iterable<Type> types = const <Type>[TicketCategory];
  @override
  final String wireName = 'TicketCategory';

  @override
  Object serialize(Serializers serializers, TicketCategory object,
          {FullType specifiedType = FullType.unspecified}) =>
      _toWire[object.name] ?? object.name;

  @override
  TicketCategory deserialize(Serializers serializers, Object serialized,
          {FullType specifiedType = FullType.unspecified}) =>
      TicketCategory.valueOf(
          _fromWire[serialized] ?? (serialized is String ? serialized : ''));
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
