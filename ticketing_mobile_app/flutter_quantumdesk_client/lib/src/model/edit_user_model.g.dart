// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'edit_user_model.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$EditUserModel extends EditUserModel {
  @override
  final User? user;
  @override
  final BuiltList<String>? selectedRoles;

  factory _$EditUserModel([void Function(EditUserModelBuilder)? updates]) =>
      (new EditUserModelBuilder()..update(updates))._build();

  _$EditUserModel._({this.user, this.selectedRoles}) : super._();

  @override
  EditUserModel rebuild(void Function(EditUserModelBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  EditUserModelBuilder toBuilder() => new EditUserModelBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is EditUserModel &&
        user == other.user &&
        selectedRoles == other.selectedRoles;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, user.hashCode);
    _$hash = $jc(_$hash, selectedRoles.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'EditUserModel')
          ..add('user', user)
          ..add('selectedRoles', selectedRoles))
        .toString();
  }
}

class EditUserModelBuilder
    implements Builder<EditUserModel, EditUserModelBuilder> {
  _$EditUserModel? _$v;

  UserBuilder? _user;
  UserBuilder get user => _$this._user ??= new UserBuilder();
  set user(UserBuilder? user) => _$this._user = user;

  ListBuilder<String>? _selectedRoles;
  ListBuilder<String> get selectedRoles =>
      _$this._selectedRoles ??= new ListBuilder<String>();
  set selectedRoles(ListBuilder<String>? selectedRoles) =>
      _$this._selectedRoles = selectedRoles;

  EditUserModelBuilder() {
    EditUserModel._defaults(this);
  }

  EditUserModelBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _user = $v.user?.toBuilder();
      _selectedRoles = $v.selectedRoles?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(EditUserModel other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$EditUserModel;
  }

  @override
  void update(void Function(EditUserModelBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  EditUserModel build() => _build();

  _$EditUserModel _build() {
    _$EditUserModel _$result;
    try {
      _$result = _$v ??
          new _$EditUserModel._(
            user: _user?.build(),
            selectedRoles: _selectedRoles?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'user';
        _user?.build();
        _$failedField = 'selectedRoles';
        _selectedRoles?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'EditUserModel', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
